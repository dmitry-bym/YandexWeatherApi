using YandexWeatherApi.Helpers;
using YandexWeatherApi.Models;
using YandexWeatherApi.Result;

namespace YandexWeatherApi;

public abstract class YandexWeatherRequestBase
{
    protected abstract string WeatherType { get; }
    protected abstract string ApiVersion { get; }
    
    internal YandexWeatherRequestBase()
    {
    }

    /// <summary>
    /// Weather locality with Latitude and Longitude. Required.
    /// </summary>
    public WeatherLocality? WeatherLocality { get; set; }

    /// <summary>
    /// Language of the response. Optional.
    /// </summary>
    public WeatherLocale? WeatherLocale { get; set; }
}

public abstract class YandexWeatherRequestBase<TResponse> : YandexWeatherRequestBase
{
    private readonly IYandexWeatherClient _weatherService;
    
    internal YandexWeatherRequestBase(IYandexWeatherClient weatherService)
    {
        _weatherService = weatherService;
    }
    
    public Task<Result<TResponse>> Send(CancellationToken ct)
    {
        Validate();
        return _weatherService.Send<TResponse>(CreateRequest(), ct);
    }
    
    private YandexWeatherRequest CreateRequest()
    {
        return new YandexWeatherRequest(ApiVersion, WeatherType, GetRequestParams());
    }
    
    private IDictionary<string, string> GetRequestParams()
    {
        var dict = new Dictionary<string, string>();
        dict.AddIfValueNotNull("lat", WeatherLocality!.Latitude);
        dict.AddIfValueNotNull("lon", WeatherLocality!.Longitude);
        dict.AddIfValueNotNull("lang", WeatherLocale?.Locale);
        FillRequestParams(dict);
        return dict;
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
    
    //aggresive inlining
    protected virtual void FillRequestParams(IDictionary<string, string> dict) {}
    
    //aggresive inlining
    protected virtual void ValidateInner() { }
}
