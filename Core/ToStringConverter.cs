using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Archon.Json
{
	public class ToStringConverter<T> : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(T).IsAssignableFrom(objectType);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			string str = reader.Value as string;

			if (str == null)
				return default(T);

			var converter = TypeDescriptor.GetConverter(typeof(T));

			if (converter.CanConvertFrom(typeof(string)))
				return converter.ConvertFromString(str);

			return default(T);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (value == null)
			{
				writer.WriteNull();
			}
			else
			{
				writer.WriteValue(value.ToString());
			}
		}
	}
}