using System;
using System.Net;

namespace YandexWeatherApi
{
    public enum AccessTypeEnum
    {
        informers,
        forecast
    }

    public enum LanguageEnum
    {
        Null,       //default
        ru_RU,
        ru_UA,
        uk_UA,
        be_BY,
        kk_KZ,
        tr_TR,
        en_US
    }

    public class YandexRequest
    {
        private const string Method = "GET";
        public string ApiUri { get; set; } = "https://api.weather.yandex.ru/v1/";
        public AccessTypeEnum AccessType { get; set; } = AccessTypeEnum.forecast;
        public LanguageEnum Language { get; set; } = LanguageEnum.Null;

        public string AccessToken { get; set; } // X-Yandex-API-Key
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Limit { get; set; }
        public bool Hours { get; set; } = true;
        public bool Extra { get; set; } = false;

        public HttpWebRequest Request
        {
            get
            {
                var request = WebRequest.CreateHttp(GetUri());
                request.Headers.Add("X-Yandex-API-Key", AccessToken);
                request.Method = Method;
                return request;
            }
        }

        public YandexRequest(string accessToken)
            => AccessToken = accessToken;

        public YandexRequest(AccessTypeEnum type, string accessToken)
        {
            AccessToken = accessToken;
            AccessType = type;
        }

        public YandexRequest(AccessTypeEnum type, LanguageEnum lang, string accessToken)
        {
            AccessToken = accessToken;
            AccessType = type;
            Language = lang;
        }

        private Uri GetUri()
        {
            return new Uri(new Uri(ApiUri), ParametersForLink);
        }

        private string ParametersForLink
        {
            get
            {
                var str = AccessType.ToString();

                str += "?lat=" + Latitude + "&lon=" + Longitude; // if lat and lon incorrect that in response will be data for Moscow

                if (Language != LanguageEnum.Null)
                    str += "&lang=" + Language.ToString();

                str += "&limit=" + Limit.ToString();
                str += "&hours=" + Hours;
                str += "&extra=" + Extra;
                return str;
            }
        }

    }
}
