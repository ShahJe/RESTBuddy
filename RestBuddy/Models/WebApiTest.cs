using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace RestBuddy
{
	[Serializable]
	public class WebApiTest
	{
		public WebApiTest()
		{
			CustomHeaders = new CustomHeaders();
		}

		public string BaseUri { get; set; }

		public string RequestUserName { get; set; }

		public string RequestPassword { get; set; }

		public string OutputFormat { get; set; }

		public bool SendRequestAuthCredentials { get; set; }		

		public string Name { get; set; }

		public string EndpointUri { get; set; }

		public string HttpMethod { get; set; }		

		public string MessageBody { get; set; }

		public bool IsEnabled { get; set; }

		public CustomHeaders CustomHeaders { get; set; }

		public HttpStatusCode ExpectedHttpStatusCode { get; set; }

		public HttpStatusCode ResultHttpStatusCode { get; set; }

		public bool? IsTestSuccess { get; set; }

		public string ResultContent { get; set; }

		public override string ToString()
		{
			return Name;
		}

		public HttpResponseMessage Run()
		{
			if (!IsEnabled)
			{
				return null;
			}

			HttpResponseMessage response;

			try
			{
				var handler = new HttpClientHandler();

				if (SendRequestAuthCredentials)
				{
					handler.Credentials = new NetworkCredential(RequestUserName, RequestPassword);
					handler.PreAuthenticate = true;
				}

				var client = new HttpClient(handler);
				client.BaseAddress = new Uri(BaseUri);
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(OutputFormat));

				foreach (var header in CustomHeaders.Headers)
				{
					client.DefaultRequestHeaders.Add(header.Key, header.Value);
				}

				if (HttpMethod == "POST")
				{
					MessageBody.ValidateNotNullOrEmpty("Message body cannot be empty.");

					var uri = new Uri(BaseUri + EndpointUri);
					
					try
					{
						var obj = JsonConvert.DeserializeObject(MessageBody);
						response = client.PostAsJsonAsync(uri, obj).Result;
					}
					catch
					{
						throw;
					}
				}
				else
				{
					response = client.GetAsync(EndpointUri).Result;
				}
			}
			catch (Exception ex)
			{
				// ReasonPhrase cannot have new line characters.
				var message = ex.GetBaseException().Message.Replace(Environment.NewLine, "<br/>");
				response = new HttpResponseMessage { StatusCode = HttpStatusCode.InternalServerError, ReasonPhrase = message };
			}

			if (response.Content != null)
			{
				ResultContent = response.Content.ReadAsStringAsync().Result;

				if (string.IsNullOrEmpty(ResultContent))
				{
					ResultContent = response.ReasonPhrase;
				}
			}
			else
			{
				ResultContent = response.ReasonPhrase;
			}

			ResultHttpStatusCode = response.StatusCode;
			IsTestSuccess = response.StatusCode == ExpectedHttpStatusCode;

			return response;
		}		
	}
}
