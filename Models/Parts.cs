using Newtonsoft.Json;

namespace YandexWeatherApi.Models
{
    public class Parts
    {
        [JsonProperty("part_name")]
        public string DayPartName { get; set; }

        [JsonProperty("temp_min")]
        public int DayTemperatureMinimum { get; set; }

        [JsonProperty("temp_max")]
        public int DayTemperatureMaximum { get; set; }

        [JsonProperty("temp_avg")]
        public int AverageTemperature { get; set; }

        [JsonProperty("feels_like")]
        public int FeelsLikeTemperature { get; set; }

        [JsonProperty("icon")]
        public string IconUrl { get; set; }

        [JsonProperty("condition")]
        public string Condition { get; set; }

        [JsonProperty("daytime")]
        public string DayTime { get; set; }

        [JsonProperty("polar")]
        public bool Polar { get; set; }

        [JsonProperty("wind_speed")]
        public float WindSpeed { get; set; }

        [JsonProperty("wind_gust")]
        public float WindGust { get; set; }

        [JsonProperty("wind_dir")]
        public string WindDirection { get; set; }

        [JsonProperty("pressure_mm")]
        public int PressureInMm { get; set; }

        [JsonProperty("pressure_pa")]
        public int PressureInPa { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("prec_mm")]
        public int ExpectedPrecipitationInMm { get; set; }

        [JsonProperty("prec_period")]
        public int ExpectedPrecipitationPeriodInMinutes { get; set; }

        [JsonProperty("prec_prob")]
        public int ProbabilityPrecipitation { get; set; }
    }
}
