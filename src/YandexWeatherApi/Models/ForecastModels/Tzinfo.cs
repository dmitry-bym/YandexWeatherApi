using System.Text.Json.Serialization;

namespace YandexWeatherApi.Models.ForecastModels;

public class Tzinfo
{
    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("abbr")] public string Abbr { get; set; }

    [JsonPropertyName("dst")] public bool Dst { get; set; }

    [JsonPropertyName("offset")] public int Offset { get; set; }
}