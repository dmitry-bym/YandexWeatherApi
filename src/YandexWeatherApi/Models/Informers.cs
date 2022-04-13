using System.Text.Json.Serialization;

namespace YandexWeatherApi.Models;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Info
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lon")]
        public double Lon { get; set; }
    }

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

    public class Part
    {
        [JsonPropertyName("part_name")]
        public string PartName { get; set; }

        [JsonPropertyName("temp_min")]
        public int TempMin { get; set; }

        [JsonPropertyName("temp_avg")]
        public int TempAvg { get; set; }

        [JsonPropertyName("temp_max")]
        public int TempMax { get; set; }

        [JsonPropertyName("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("wind_gust")]
        public double WindGust { get; set; }

        [JsonPropertyName("wind_dir")]
        public string WindDir { get; set; }

        [JsonPropertyName("pressure_mm")]
        public int PressureMm { get; set; }

        [JsonPropertyName("pressure_pa")]
        public int PressurePa { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("prec_mm")]
        public int PrecMm { get; set; }

        [JsonPropertyName("prec_prob")]
        public int PrecProb { get; set; }

        [JsonPropertyName("prec_period")]
        public int PrecPeriod { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("condition")]
        public string Condition { get; set; }

        [JsonPropertyName("feels_like")]
        public int FeelsLike { get; set; }

        [JsonPropertyName("daytime")]
        public string Daytime { get; set; }

        [JsonPropertyName("polar")]
        public bool Polar { get; set; }
    }

    public class Forecast
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("date_ts")]
        public int DateTs { get; set; }

        [JsonPropertyName("week")]
        public int Week { get; set; }

        [JsonPropertyName("sunrise")]
        public string Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public string Sunset { get; set; }

        [JsonPropertyName("moon_code")]
        public int MoonCode { get; set; }

        [JsonPropertyName("moon_text")]
        public string MoonText { get; set; }

        [JsonPropertyName("parts")]
        public List<Part> Parts { get; set; }
    }

    public class Informers
    {
        [JsonPropertyName("now")]
        public int Now { get; set; }

        [JsonPropertyName("now_dt")]
        public DateTime NowDt { get; set; }

        [JsonPropertyName("info")]
        public Info Info { get; set; }

        [JsonPropertyName("fact")]
        public Fact Fact { get; set; }

        [JsonPropertyName("forecast")]
        public Forecast Forecast { get; set; }
    }


