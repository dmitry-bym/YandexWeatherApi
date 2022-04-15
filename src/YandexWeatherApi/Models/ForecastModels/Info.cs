using System.Text.Json.Serialization;

namespace YandexWeatherApi.Models.ForecastModels;

public class Info
{
    [JsonPropertyName("n")] public bool N { get; set; }

    [JsonPropertyName("geoid")] public int Geoid { get; set; }

    [JsonPropertyName("url")] public string? Url { get; set; }

    [JsonPropertyName("lat")] public double Lat { get; set; }

    [JsonPropertyName("lon")] public double Lon { get; set; }

    [JsonPropertyName("tzinfo")] public Tzinfo? Tzinfo { get; set; }

    [JsonPropertyName("def_pressure_mm")] public int DefPressureMm { get; set; }

    [JsonPropertyName("def_pressure_pa")] public int DefPressurePa { get; set; }

    [JsonPropertyName("slug")] public string? Slug { get; set; }

    [JsonPropertyName("zoom")] public int Zoom { get; set; }

    [JsonPropertyName("nr")] public bool Nr { get; set; }

    [JsonPropertyName("ns")] public bool Ns { get; set; }

    [JsonPropertyName("nsr")] public bool Nsr { get; set; }

    [JsonPropertyName("p")] public bool P { get; set; }

    [JsonPropertyName("f")] public bool F { get; set; }

    [JsonPropertyName("_h")] public bool H { get; set; }
}