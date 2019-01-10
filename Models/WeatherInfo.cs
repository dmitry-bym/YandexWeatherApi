using Newtonsoft.Json;

namespace YandexWeatherApi.Models
{
    public class WeatherInfo
    {
        [JsonProperty("now")]
        public int ServerTimeUnix { get; set; }

        [JsonProperty("now_dt")]
        public string ServerTimeUtc { get; set; }

        [JsonProperty("info")]
        public PlaceInfo Info { get; set; }

        [JsonProperty("fact")]
        public Factual Fact { get; set; }

        [JsonProperty("forecast")]
        public Forecast Forecast { get; set; }
    }
}
