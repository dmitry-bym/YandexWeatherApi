using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using YandexWeatherApi.Models;

namespace YandexWeatherApi
{
    public class YandexService
    {
        private readonly HttpWebRequest _request;

        public YandexService(YandexRequest request)
        {
            _request = request.Request ?? throw new ArgumentNullException("Request"); ;
        }

        private WeatherInfo GetWeatherInfo()
        {
            using (var response = _request.GetResponse())
            {
                var responseStream = response.GetResponseStream() ?? throw new ArgumentNullException("Response", "incorrect request");

                using (var stream = new StreamReader(responseStream))
                {
                    var weatherInfoString = stream.ReadToEnd();
                    return JsonConvert.DeserializeObject<WeatherInfo>(weatherInfoString);
                }
            };
        }
    }
}