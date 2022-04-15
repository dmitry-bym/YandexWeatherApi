using System.Text.Json.Serialization;

namespace YandexWeatherApi.Models.ForecastModels;

public class Yesterday
{
    [JsonPropertyName("temp")] public int Temp { get; set; }
}