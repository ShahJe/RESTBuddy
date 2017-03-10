using System;
using System.Collections.Generic;
using System.Text;

namespace RestBuddy
{
	public static class StringExtensions
	{
		public static string ValueOrNull(this string value)
		{
			return string.IsNullOrEmpty(value) ? null : value.Trim();
		}

		public static void ValidateNotNullOrEmpty(this string value, string errorMessage)
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new Exception(errorMessage);
			}
		}

		public static string Serialize<T>(List<T> value)
		{
			var serialized = new StringBuilder();

			foreach (var val in value)
			{
				serialized.AppendLine(val.ToString());
			}

			return serialized.ToString();
		}

		public static string Serialize(List<string> value)
		{
			return string.Join("; ", value);
		}
	}
}
