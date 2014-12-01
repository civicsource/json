using System;
using Archon.Enums;
using Newtonsoft.Json;

namespace Archon.Json
{
	/// <summary>
	/// Converts an <see cref="Enum"/> to an object with its value and description defined.
	/// </summary>
	public class ExpandedEnumConverter : DescriptionEnumConverter
	{
		public override bool CanConvert(Type objectType)
		{
			Type t = (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Nullable<>)) ? Nullable.GetUnderlyingType(objectType) : objectType;
			return t.IsEnum;
		}

		public override bool CanRead
		{
			get { return false; }
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (value == null)
			{
				writer.WriteNull();
				return;
			}

			Enum e = (Enum)value;

			writer.WriteStartObject();

			writer.WritePropertyName("value");
			writer.WriteValue(e.ToString());

			writer.WritePropertyName("description");
			writer.WriteValue(e.DescriptionOf());

			writer.WriteEndObject();
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			throw new NotSupportedException("ExpandedEnumConverter does not read JSON");
		}
	}
}