using System.Text.Json.Serialization;

namespace dotnet_API.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RPGClass
    {
       Knight = 1,
       Mage = 2,
       Cleric = 3
    }
}