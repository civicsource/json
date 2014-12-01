using System;
using Archon.Enums;
using Newtonsoft.Json;

namespace Archon.Json
{
	/// <summary>
	/// Converts an <see cref="Enum"/> to its description value.
	/// </summary>
	public class DescriptionEnumConverter : JsonConverter
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
			writer.WriteValue(e.DescriptionOf());
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			throw new NotSupportedException("DescriptionEnumConverter does not read JSON");
		}
	}
}