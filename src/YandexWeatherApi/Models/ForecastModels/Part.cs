using System.Text.Json.Serialization;

namespace YandexWeatherApi.Models.ForecastModels;

public class Part
{
    [JsonPropertyName("_source")] public string? Source { get; set; }

    [JsonPropertyName("temp_min")] public int TempMin { get; set; }

    [JsonPropertyName("temp_avg")] public int TempAvg { get; set; }

    [JsonPropertyName("temp_max")] public int TempMax { get; set; }

    [JsonPropertyName("wind_speed")] public double WindSpeed { get; set; }

    [JsonPropertyName("wind_gust")] public double WindGust { get; set; }

    [JsonPropertyName("wind_dir")] public string? WindDir { get; set; }

    [JsonPropertyName("pressure_mm")] public float PressureMm { get; set; }

    [JsonPropertyName("pressure_pa")] public float PressurePa { get; set; }

    [JsonPropertyName("humidity")] public int Humidity { get; set; }

    [JsonPropertyName("soil_temp")] public int SoilTemp { get; set; }

    [JsonPropertyName("soil_moisture")] public double SoilMoisture { get; set; }

    [JsonPropertyName("prec_mm")] public float PrecMm { get; set; }

    [JsonPropertyName("prec_prob")] public int PrecProb { get; set; }

    [JsonPropertyName("prec_period")] public int PrecPeriod { get; set; }

    [JsonPropertyName("cloudness")] public float Cloudness { get; set; }

    [JsonPropertyName("prec_type")] public int PrecType { get; set; }

    [JsonPropertyName("prec_strength")] public float PrecStrength { get; set; }

    [JsonPropertyName("icon")] public string? Icon { get; set; }

    [JsonPropertyName("condition")] public string? Condition { get; set; }

    [JsonPropertyName("uv_index")] public int UvIndex { get; set; }

    [JsonPropertyName("feels_like")] public int FeelsLike { get; set; }

    [JsonPropertyName("daytime")] public string? Daytime { get; set; }

    [JsonPropertyName("polar")] public bool Polar { get; set; }
}