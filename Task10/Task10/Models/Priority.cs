using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Task10.Models;

[JsonConverter(typeof(StringEnumConverter))]
public enum Priority
{
    High,
    Medium,
    Low
}