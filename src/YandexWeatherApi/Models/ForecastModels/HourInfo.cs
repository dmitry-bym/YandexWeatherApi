using System.Text.Json.Serialization;

namespace YandexWeatherApi.Models.ForecastModels;

public class HourInfo
{
    [JsonPropertyName("hour")] public string? Hour { get; set; }

    [JsonPropertyName("hour_ts")] public int HourTs { get; set; }

    [JsonPropertyName("temp")] public int Temp { get; set; }

    [JsonPropertyName("feels_like")] public int FeelsLike { get; set; }

    [JsonPropertyName("icon")] public string? Icon { get; set; }

    [JsonPropertyName("condition")] public string? Condition { get; set; }

    [JsonPropertyName("cloudness")] public float Cloudness { get; set; }

    [JsonPropertyName("prec_type")] public int PrecType { get; set; }

    [JsonPropertyName("prec_strength")] public float PrecStrength { get; set; }

    [JsonPropertyName("is_thunder")] public bool IsThunder { get; set; }

    [JsonPropertyName("wind_dir")] public string? WindDir { get; set; }

    [JsonPropertyName("wind_speed")] public double WindSpeed { get; set; }

    [JsonPropertyName("wind_gust")] public double WindGust { get; set; }

    [JsonPropertyName("pressure_mm")] public float PressureMm { get; set; }

    [JsonPropertyName("pressure_pa")] public float PressurePa { get; set; }

    [JsonPropertyName("humidity")] public int Humidity { get; set; }

    [JsonPropertyName("uv_index")] public int UvIndex { get; set; }

    [JsonPropertyName("soil_temp")] public int SoilTemp { get; set; }

    [JsonPropertyName("soil_moisture")] public double SoilMoisture { get; set; }

    [JsonPropertyName("prec_mm")] public float PrecMm { get; set; }

    [JsonPropertyName("prec_period")] public int PrecPeriod { get; set; }

    [JsonPropertyName("prec_prob")] public int PrecProb { get; set; }
}