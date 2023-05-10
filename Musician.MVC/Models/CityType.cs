using System.Text.Json.Serialization;

namespace WeatherCast.Models
{
    public class CityType
    {
        [JsonPropertyName("il")]
        public string Il { get; set; }

       
    }


}
