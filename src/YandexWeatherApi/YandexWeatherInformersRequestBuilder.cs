using YandexWeatherApi.Models;

namespace YandexWeatherApi;

public sealed class YandexWeatherInformersRequestBuilder
{
    private readonly YandexWeatherService _weatherService;
    internal YandexWeatherInformersRequestBuilder(YandexWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public const string WeatherType = "informers";

    public const string ApiVersion = "v2";

    public WeatherLocality? WeatherLocality { get; set; }

    public WeatherLocale? WeatherLocale { get; set; }


    public Task<Root> Send(CancellationToken ct)
    {
        Validate();
        return _weatherService.Send<Root>(CreateRequest(), ct);
    }
    
    private IWeatherRequest CreateRequest()
    {
        var parameters = GetRequestParams();
        return new YandexWeatherRequest(ApiVersion, WeatherType, parameters);
    }
    private IEnumerable<(string Name, string Value)> GetRequestParams()
    {
        yield return ("lat", WeatherLocality!.Latitude);
        yield return ("lon", WeatherLocality!.Longitude);

        if (WeatherLocale is not null)
            yield return ("lang", WeatherLocale.Locale);
    }

    private void Validate()
    {
        if (WeatherLocality is null)
            throw new NotImplementedException();

        if (string.IsNullOrEmpty(WeatherLocality.Latitude))
            throw new NotImplementedException();

        if (string.IsNullOrEmpty(WeatherLocality.Longitude))
            throw new NotImplementedException();
    }
}
