using System.Text.Json.Serialization;

namespace YandexWeatherApi.Models.ForecastModels;

public class ForecastResponse
{
    [JsonPropertyName("now")] public int Now { get; set; }

    [JsonPropertyName("now_dt")] public DateTime NowDt { get; set; }

    [JsonPropertyName("info")] public Info Info { get; set; }

    [JsonPropertyName("geo_object")] public GeoObject GeoObject { get; set; }

    [JsonPropertyName("yesterday")] public Yesterday Yesterday { get; set; }

    [JsonPropertyName("fact")] public Fact Fact { get; set; }

    [JsonPropertyName("forecasts")] public List<Forecast> Forecasts { get; set; }
}
