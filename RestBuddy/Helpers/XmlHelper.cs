using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using static System.Windows.Forms.ComboBox;

namespace RestBuddy
{
	public static class XmlHelper
	{
		private const string recentFileName = "recent.xml";
		private const string xslFileName = "defaultss.xsl";
		private const string testFileName = "tests.xml";

		public static List<WebApiTest> LoadTests(string fileName)
		{
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException("Unable to open " + fileName);
			}

			var tests = new List<WebApiTest>();

			try
			{
				var xmlDoc = new XmlDocument();
				using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
				{
					xmlDoc.Load(fs);
					fs.Close();
				}

				var document = xmlDoc.DocumentElement;				
				var baseTest = new WebApiTest();

				if (document != null && document.ChildNodes.Count > 0)
				{
					for (var i = 0; i < document.ChildNodes.Count; i++)
					{
						var node = document.ChildNodes.Item(i);

						if (node == null)
						{
							continue;
						}

						baseTest = MapObject(baseTest, node);
					}

					var testConfigs = document.GetElementsByTagName("test");

					for (var i = 0; i < testConfigs.Count; i++)
					{
						var node = testConfigs.Item(i);
						tests.Add(GetObjectFromXml(node, baseTest));
					}
				}				
			}
			catch (Exception ex)
			{
				var errorCode = Marshal.GetHRForException(ex) & ((1 << 16) - 1);
				if ((errorCode == 32 || errorCode == 33))
				{
					throw new FileLoadException("Auto test config file is open in another program.");
				}
				else
				{
					throw new FileLoadException("Error processing auto test config file.");
				}
			}

			return tests;
		}		

		private static WebApiTest GetObjectFromXml(XmlNode node, WebApiTest baseTest)
		{
			var test = new WebApiTest();

			if (node != null && node.Attributes != null && node.HasChildNodes)
			{
				test.RequestUserName = baseTest.RequestUserName;
				test.RequestPassword = baseTest.RequestPassword;
				test.BaseUri = baseTest.BaseUri;
				test.OutputFormat = baseTest.OutputFormat;
				test.SendRequestAuthCredentials = baseTest.SendRequestAuthCredentials;				
				test.IsEnabled = Convert.ToBoolean(node.Attributes.Item(0).Value);

				for (var j = 0; j < node.ChildNodes.Count; j++)
				{
					var child = node.ChildNodes.Item(j);
					test = MapObject(test, child);
				}
			}

			return test;
		}

		private static WebApiTest MapObject(WebApiTest test, XmlNode node)
		{
			switch (node.Name)
			{
				case "name":
					test.Name = node.InnerText;
					break;
				case "endpoint":
					test.EndpointUri = node.InnerText;
					break;
				case "httpmethod":
					test.HttpMethod = node.InnerText;
					break;
				case "sendrequestauthcredentials":
					test.SendRequestAuthCredentials = Convert.ToBoolean(node.InnerText);
					break;
				case "body":
					test.MessageBody = node.InnerText;
					break;
				case "requestusername":
					test.RequestUserName = node.InnerText;
					break;
				case "requestpassword":
					test.RequestPassword = node.InnerText;
					break;
				case "baseuri":
					test.BaseUri = node.InnerText;
					break;
				case "output":
					test.OutputFormat = node.InnerText;
					break;
				case "expectedhttpcode":
					test.ExpectedHttpStatusCode = (HttpStatusCode)Convert.ToInt32(node.InnerText);
					break;
				case "headers":
					foreach (XmlNode header in node.ChildNodes)
					{
						test.CustomHeaders.Headers.Add(header.Attributes.Item(0).Value, header.InnerText);
					}

					break;
			}

			return test;
		}

		public static List<string> LoadRecent()
		{
			if (!File.Exists(recentFileName))
			{
				return new List<string> { testFileName };
			}

			var files = new List<string>();

			try
			{
				var xmlDoc = new XmlDocument();
				using (var fs = new FileStream(recentFileName, FileMode.Open, FileAccess.Read))
				{
					xmlDoc.Load(fs);
					fs.Close();
				}

				var document = xmlDoc.DocumentElement;
				

				if (document != null && document.ChildNodes.Count > 0)
				{
					for (var i = 0; i < document.ChildNodes.Count; i++)
					{
						var node = document.ChildNodes.Item(i);

						if (node == null)
						{
							continue;
						}

						files.Add(node.InnerText);
					}					
				}
			}
			catch (Exception ex)
			{
				var errorCode = Marshal.GetHRForException(ex) & ((1 << 16) - 1);
				if ((errorCode == 32 || errorCode == 33))
				{
					throw new FileLoadException("Auto test config file is open in another program.");
				}
				else
				{
					throw new FileLoadException("Error processing auto test config file.");
				}
			}

			return files;
		}

		public static void WriteRecentFiles(ObjectCollection files)
		{
			var xmlWriter = new XmlTextWriter(recentFileName, null);
			xmlWriter.WriteStartDocument();
			xmlWriter.WriteStartElement("files");

			foreach (var file in files)
			{
				xmlWriter.WriteStartElement("file");
				xmlWriter.WriteString(file.ToString());
				xmlWriter.WriteEndElement();
			}

			xmlWriter.WriteEndElement();
			xmlWriter.WriteEndDocument();
			xmlWriter.Close();
		}

		public static XslCompiledTransform LoadXsl()
		{
			var xct = new XslCompiledTransform();

			try
			{
				var xls = File.Open(xslFileName, FileMode.Open, FileAccess.Read);
				var reader = XmlReader.Create(xls);				
				xct.Load(reader);				
			}
			catch
			{
				//// Ignore xml stylesheet load errors.
			}

			return xct;
		}

		public static string GetFormattedStringForBrowser(string displayText, XslCompiledTransform xsl)
		{
			var formattedString = string.Empty; ;

			if (string.IsNullOrEmpty(displayText))
			{
				return formattedString;
			}

			if (displayText.StartsWith("<!DOCTYPE html"))
			{
				// If html web page is returned then display it as is.
				formattedString = displayText;
				return formattedString;
			}

			try
			{
				if (xsl == null)
				{
					// If unable to load XML stylesheet then make sure browser can display XML as text.
					formattedString = WebUtility.HtmlEncode(displayText);
					return formattedString;
				}

				var document = new XmlDocument();
				document.LoadXml(displayText);

				var builder = new StringBuilder();
				var writer = XmlWriter.Create(builder);
				xsl.Transform(document, writer);

				formattedString = builder.ToString();
			}
			catch
			{
				formattedString = displayText;
			}

			return formattedString;
		}
	}
}
