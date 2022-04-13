using System.Text.Json.Serialization;

namespace YandexWeatherApi.Models;

public record Info(
    [property: JsonPropertyName("lat")] double Lat,
    [property: JsonPropertyName("lon")] double Lon,
    [property: JsonPropertyName("url")] string Url
);

public record Fact(
    [property: JsonPropertyName("temp")] int Temp,
    [property: JsonPropertyName("feels_like")] int FeelsLike,
    [property: JsonPropertyName("icon")] string Icon,
    [property: JsonPropertyName("condition")] string Condition,
    [property: JsonPropertyName("wind_speed")] int WindSpeed,
    [property: JsonPropertyName("wind_gust")] double WindGust,
    [property: JsonPropertyName("wind_dir")] string WindDir,
    [property: JsonPropertyName("pressure_mm")] int PressureMm,
    [property: JsonPropertyName("pressure_pa")] int PressurePa,
    [property: JsonPropertyName("humidity")] int Humidity,
    [property: JsonPropertyName("daytime")] string Daytime,
    [property: JsonPropertyName("polar")] bool Polar,
    [property: JsonPropertyName("season")] string Season,
    [property: JsonPropertyName("obs_time")] int ObsTime
);

public record Part(
    [property: JsonPropertyName("part_name")] string PartName,
    [property: JsonPropertyName("temp_min")] int TempMin,
    [property: JsonPropertyName("temp_max")] int TempMax,
    [property: JsonPropertyName("temp_avg")] int TempAvg,
    [property: JsonPropertyName("feels_like")] int FeelsLike,
    [property: JsonPropertyName("icon")] string Icon,
    [property: JsonPropertyName("condition")] string Condition,
    [property: JsonPropertyName("daytime")] string Daytime,
    [property: JsonPropertyName("polar")] bool Polar,
    [property: JsonPropertyName("wind_speed")] double WindSpeed,
    [property: JsonPropertyName("wind_gust")] int WindGust,
    [property: JsonPropertyName("wind_dir")] string WindDir,
    [property: JsonPropertyName("pressure_mm")] int PressureMm,
    [property: JsonPropertyName("pressure_pa")] int PressurePa,
    [property: JsonPropertyName("humidity")] int Humidity,
    [property: JsonPropertyName("prec_mm")] int PrecMm,
    [property: JsonPropertyName("prec_period")] int PrecPeriod,
    [property: JsonPropertyName("prec_prob")] int PrecProb
);

public record Forecast(
    [property: JsonPropertyName("date")] string Date,
    [property: JsonPropertyName("date_ts")] int DateTs,
    [property: JsonPropertyName("week")] int Week,
    [property: JsonPropertyName("sunrise")] string Sunrise,
    [property: JsonPropertyName("sunset")] string Sunset,
    [property: JsonPropertyName("moon_code")] int MoonCode,
    [property: JsonPropertyName("moon_text")] string MoonText,
    [property: JsonPropertyName("parts")] IReadOnlyList<Part> Parts
);

public record Informers(
    [property: JsonPropertyName("now")] int Now,
    [property: JsonPropertyName("now_dt")] DateTime NowDt,
    [property: JsonPropertyName("info")] Info Info,
    [property: JsonPropertyName("fact")] Fact Fact,
    [property: JsonPropertyName("forecast")] Forecast Forecast
);
