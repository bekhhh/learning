using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Task10;

[JsonConverter(typeof(StringEnumConverter))]
public enum PriorityType
{
    High,
    Medium,
    Low
}