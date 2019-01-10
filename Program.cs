using System.Configuration;

namespace YandexWeatherApi
{
    class Program
    {
        static void Main()
        {
            var khv = new YandexRequest(AccessTypeEnum.informers, LanguageEnum.en_US, ConfigurationManager.AppSettings.Get("AccessToken"));
            khv.Latitude = "45.088364";
            khv.Longitude = "133.495643";
            khv.Limit = 3;
            khv.Extra = true;
            var service = new YandexService(khv);
            var weatherInfo = service.GetWeatherInfo();
        }
    }
}
