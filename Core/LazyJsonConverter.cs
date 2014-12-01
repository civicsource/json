using System;
using Newtonsoft.Json;

namespace Archon.Json
{
	public class LazyJsonConverter<T> : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(Lazy<T>).IsAssignableFrom(objectType);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (!(reader.Value is T))
				return default(T);

			return new Lazy<T>(() => (T)reader.Value);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var future = value as Lazy<T>;

			if (future == null)
			{
				writer.WriteNull();
			}
			else
			{
				writer.WriteValue(future.Value);
			}
		}
	}
}