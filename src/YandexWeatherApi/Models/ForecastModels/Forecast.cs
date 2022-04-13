using System.Text.Json.Serialization;

namespace YandexWeatherApi.Models.ForecastModels;

public class Forecast
{
    [JsonPropertyName("date")] public string Date { get; set; }

    [JsonPropertyName("date_ts")] public int DateTs { get; set; }

    [JsonPropertyName("week")] public int Week { get; set; }

    [JsonPropertyName("sunrise")] public string Sunrise { get; set; }

    [JsonPropertyName("sunset")] public string Sunset { get; set; }

    [JsonPropertyName("rise_begin")] public string RiseBegin { get; set; }

    [JsonPropertyName("set_end")] public string SetEnd { get; set; }

    [JsonPropertyName("moon_code")] public int MoonCode { get; set; }

    [JsonPropertyName("moon_text")] public string MoonText { get; set; }

    [JsonPropertyName("parts")] public Parts Parts { get; set; }

    [JsonPropertyName("hours")] public List<HourInfo> Hours { get; set; }

    [JsonPropertyName("biomet")] public Biomet Biomet { get; set; }
}