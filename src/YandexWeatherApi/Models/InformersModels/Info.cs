using System.Text.Json.Serialization;

namespace YandexWeatherApi.Models.InformersModels;

public class Info
{
    [JsonPropertyName("url")] public string? Url { get; set; }

    [JsonPropertyName("lat")] public double Lat { get; set; }

    [JsonPropertyName("lon")] public double Lon { get; set; }
}
