using System.Text.Json.Serialization;

namespace YandexWeatherApi.Models.InformersModels;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);

public class InformersResponse
    {
        [JsonPropertyName("now")]
        public int Now { get; set; }

        [JsonPropertyName("now_dt")]
        public DateTime NowDt { get; set; }

        [JsonPropertyName("info")]
        public Info Info { get; set; }

        [JsonPropertyName("fact")]
        public Fact Fact { get; set; }

        [JsonPropertyName("forecast")]
        public Forecast Forecast { get; set; }
    }


