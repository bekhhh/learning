using System.Text.Json.Serialization;

namespace Task10.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Priority
{
    High,
    Medium,
    Low
}