using System.Text.Json.Serialization;

namespace YandexWeatherApi.Models.ForecastModels;

public class Parts
{
    [JsonPropertyName("day")] public Part? Day { get; set; }

    [JsonPropertyName("morning")] public Part? Morning { get; set; }

    [JsonPropertyName("day_short")] public PartShort? DayShort { get; set; }

    [JsonPropertyName("evening")] public Part? Evening { get; set; }

    [JsonPropertyName("night_short")] public PartShort? NightShort { get; set; }

    [JsonPropertyName("night")] public Part? Night { get; set; }
}