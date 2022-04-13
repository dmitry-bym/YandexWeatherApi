using System.Text.Json.Serialization;

namespace YandexWeatherApi.Models.ForecastModels;

public class GeoObject
{
    [JsonPropertyName("district")] public object District { get; set; }

    [JsonPropertyName("locality")] public Locality Locality { get; set; }

    [JsonPropertyName("province")] public Province Province { get; set; }

    [JsonPropertyName("country")] public Country Country { get; set; }
}