using Newtonsoft.Json;

namespace YandexWeatherApi.Models
{
    public class Factual
    {
        [JsonProperty("temp")]
        public int Temperature { get; set; }

        [JsonProperty("feels_like")]
        public int FeelsLikeTemperature { get; set; }

        [JsonProperty("temp_water")]
        public int WaterTemperature { get; set; }

        [JsonProperty("icon")]
        public string IconUrl { get; set; }

        [JsonProperty("condition")]
        public string Condition { get; set; }

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

        [JsonProperty("daytime")]
        public string DayTime { get; set; }

        [JsonProperty("polar")]
        public bool Polar { get; set; }

        [JsonProperty("season")]
        public string Season { get; set; }

        [JsonProperty("obs_time")]
        public int TimeOfMeasurementUnix { get; set; }
    }
}
