using System.Collections.Generic;
using Newtonsoft.Json;

namespace YandexWeatherApi.Models
{
    public class Forecast
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("date_ts")]
        public int DateUnix { get; set; }

        [JsonProperty("week")]
        public int NumberOfWeek { get; set; }

        [JsonProperty("sunrise")]
        public string SunriseTime { get; set; }

        [JsonProperty("sunset")]
        public string SunsetTime { get; set; }

        [JsonProperty("moon_code")]
        public int MoonPhaseCode { get; set; }

        [JsonProperty("moon_text")]
        public string MoonPhaseName { get; set; }

        [JsonProperty("parts")]
        public List<Parts> DayParts { get; set; }
    }
}
