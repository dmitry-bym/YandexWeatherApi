using System.Text.Json.Serialization;

namespace YandexWeatherApi.Models.InformersModels;

public class Fact
{
    [JsonPropertyName("obs_time")]
    public int ObsTime { get; set; }

    [JsonPropertyName("temp")]
    public int Temp { get; set; }

    [JsonPropertyName("feels_like")]
    public int FeelsLike { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("condition")]
    public string Condition { get; set; }

    [JsonPropertyName("wind_speed")]
    public double WindSpeed { get; set; }

    [JsonPropertyName("wind_dir")]
    public string WindDir { get; set; }

    [JsonPropertyName("pressure_mm")]
    public int PressureMm { get; set; }

    [JsonPropertyName("pressure_pa")]
    public int PressurePa { get; set; }

    [JsonPropertyName("humidity")]
    public int Humidity { get; set; }

    [JsonPropertyName("daytime")]
    public string Daytime { get; set; }

    [JsonPropertyName("polar")]
    public bool Polar { get; set; }

    [JsonPropertyName("season")]
    public string Season { get; set; }

    [JsonPropertyName("wind_gust")]
    public double WindGust { get; set; }
}