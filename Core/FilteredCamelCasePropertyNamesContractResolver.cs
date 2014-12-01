using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Archon.Json
{
	/// <remarks>
	/// http://blogs.msdn.com/b/stuartleeks/archive/2012/09/10/automatic-camel-casing-of-properties-with-signalr-hubs.aspx
	/// </remarks>
	public class FilteredCamelCasePropertyNamesContractResolver : DefaultContractResolver
	{
		public HashSet<Assembly> AssembliesToInclude { get; set; }
		public HashSet<Type> TypesToInclude { get; set; }

		public FilteredCamelCasePropertyNamesContractResolver()
		{
			AssembliesToInclude = new HashSet<Assembly>();
			TypesToInclude = new HashSet<Type>();
		}

		protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
		{
			var jsonProperty = base.CreateProperty(member, memberSerialization);

			Type declaringType = member.DeclaringType;
			if (TypesToInclude.Contains(declaringType) || AssembliesToInclude.Contains(declaringType.Assembly))
				jsonProperty.PropertyName = ToCamelCase(jsonProperty.PropertyName);

			return jsonProperty;
		}

		string ToCamelCase(string value)
		{
			if (String.IsNullOrEmpty(value))
				return value;

			var firstChar = value[0];
			if (char.IsLower(firstChar))
				return value;

			firstChar = char.ToLowerInvariant(firstChar);
			return firstChar + value.Substring(1);
		}
	}
}