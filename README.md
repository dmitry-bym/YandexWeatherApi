# YandexWeatherApi
Wrapper for Yandex Weather.

## Create a request
Access token you should get on the Yandex site.

    var req = new YandexRequest(AccessTypeEnum.informers, LanguageEnum.en_US, ConfigurationManager.AppSettings.Get("AccessToken"));

### Adding parameters
After initialize you can also add some parameters.

    req.Latitude = "45.088364";
    req.Longitude = "133.495643";
    req.Limit = 3;
    
## Create a service
    var service = new YandexService(req);
For get the data you should use GetWeatherInfo method

    var weatherInfo = service.GetWeatherInfo();
