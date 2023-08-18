using System.Text.Json.Serialization;

namespace YandexWeatherApi.Models.InformersModels;

public class Part
{
    [JsonPropertyName("part_name")] public string? PartName { get; set; }

    [JsonPropertyName("temp_min")] public int TempMin { get; set; }

    [JsonPropertyName("temp_avg")] public int TempAvg { get; set; }

    [JsonPropertyName("temp_max")] public int TempMax { get; set; }

    [JsonPropertyName("wind_speed")] public double WindSpeed { get; set; }

    [JsonPropertyName("wind_gust")] public double WindGust { get; set; }

    [JsonPropertyName("wind_dir")] public string? WindDir { get; set; }

    [JsonPropertyName("pressure_mm")] public int PressureMm { get; set; }

    [JsonPropertyName("pressure_pa")] public int PressurePa { get; set; }

    [JsonPropertyName("humidity")] public int Humidity { get; set; }

    [JsonPropertyName("prec_mm")] public float PrecMm { get; set; }

    [JsonPropertyName("prec_prob")] public int PrecProb { get; set; }

    [JsonPropertyName("prec_period")] public int PrecPeriod { get; set; }

    [JsonPropertyName("icon")] public string? Icon { get; set; }

    [JsonPropertyName("condition")] public string? Condition { get; set; }

    [JsonPropertyName("feels_like")] public int FeelsLike { get; set; }

    [JsonPropertyName("daytime")] public string? Daytime { get; set; }

    [JsonPropertyName("polar")] public bool Polar { get; set; }
}
