using Newtonsoft.Json;

namespace YandexWeatherApi.Models
{
    public class PlaceInfo
    {
        [JsonProperty("lat")]
        public float Latitude { get; set; }

        [JsonProperty("lon")]
        public float Longitude { get; set; }

        [JsonProperty("url")]
        public string CitySiteUrl { get; set; }
    }
}
