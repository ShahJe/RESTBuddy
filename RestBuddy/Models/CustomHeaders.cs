using System.Collections.Generic;
using System.Text;

namespace RestBuddy
{
	public class CustomHeaders
	{
		public CustomHeaders()
		{
			Headers = new Dictionary<string, string>();
		}

		public Dictionary<string, string> Headers { get; set; }

		public override string ToString()
		{
			StringBuilder output = new StringBuilder();

			foreach (var header in Headers)
			{
				output.AppendFormat("{0}:{1}, ", header.Key, header.Value);
			}

			return output.ToString();
		}
	}
}
