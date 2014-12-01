using System;
using Newtonsoft.Json;

namespace Archon.Json
{
	public class StringTrimmingConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(string);
		}

		public override bool CanRead
		{
			get { return true; }
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			string str = reader.Value as string;

			if (str == null)
				return null;

			return str.Trim();
		}

		public override bool CanWrite
		{
			get { return true; }
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			string str = value as string;

			if (str == null)
			{
				writer.WriteNull();
			}
			else
			{
				writer.WriteValue(str.Trim());
			}
		}
	}
}