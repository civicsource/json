# Archon JSON Utilities

> Useful JSON converters and helpers.

## How to Use

Install via [nuget](https://www.nuget.org/packages/Archon.Json/)

```
install-package Archon.Json
install-package Archon.Json.Enums
```

The following converters and utilities can be found in the `Archon.Json` namespace. For a primer on how to use these JSON converters and resolvers, see the [Json.Net documentation](http://james.newtonking.com/json/help/index.html).

### `FilteredCamelCasePropertyNamesContractResolver`

[See here](http://blogs.msdn.com/b/stuartleeks/archive/2012/09/10/automatic-camel-casing-of-properties-with-signalr-hubs.aspx) for why this class is necessary. It camel cases property names for types only within the assembly you specify.

### `LazyJsonConverter`

This converter converts any `Lazy<T>` thing to the actual `T`. E.g., an object with a `Lazy<string>` property on it would have that property be serialized as a normal `string` with this converter.

### `StringTrimmingConverter`

It does what you think it does. It trims strings when serializing and deserializing.

### `ToStringConverter<T>`

It converts the given object to a string and vice versa (using any registered `TypeConverter`s).

### DescriptionEnumConverter

It uses the [Archon Enum Utils](https://github.com/civicsource/enums) library to convert enums to their description representation and vice versa. Make sure to [install the `Archon.Json.Enums` package](https://www.nuget.org/packages/Archon.Json.Enums/).

### ExpandedEnumConverter

It uses the [Archon Enum Utils](https://github.com/civicsource/enums) library to convert enums to an object containing their original value and their description. Make sure to [install the `Archon.Json.Enums` package](https://www.nuget.org/packages/Archon.Json.Enums/).