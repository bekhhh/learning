using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Task9.Сharacters.Ability
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Element
    {        
        Earth,       
        Fire,        
        Water,        
        Air
    }   
}