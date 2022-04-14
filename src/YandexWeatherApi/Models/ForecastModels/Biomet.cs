using System.Text.Json.Serialization;

namespace YandexWeatherApi.Models.ForecastModels;

public class Biomet
{
    [JsonPropertyName("index")] public int Index { get; set; }

    [JsonPropertyName("condition")] public string? Condition { get; set; }
}