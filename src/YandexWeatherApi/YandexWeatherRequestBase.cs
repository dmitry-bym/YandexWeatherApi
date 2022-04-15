using System.Globalization;
using YandexWeatherApi.Exceptions;
using YandexWeatherApi.Helpers;
using YandexWeatherApi.Result;

namespace YandexWeatherApi;

internal abstract class YandexWeatherRequestBase<TResponse> : IYandexWeatherRequestBase<TResponse>
{
    private readonly IYandexWeatherClient _weatherService;
    protected abstract string WeatherType { get; }
    protected abstract string ApiVersion { get; }
    protected YandexWeatherRequestBase(IYandexWeatherClient weatherService)
    {
        _weatherService = weatherService;
    }

    /// <summary>
    /// Weather locality with Latitude and Longitude. Required.
    /// </summary>
    public WeatherLocality? WeatherLocality { get; set; }

    /// <summary>
    /// Language of the response. Optional.
    /// </summary>
    public WeatherLocale? WeatherLocale { get; set; }

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
        dict.AddIfValueNotNull("lat", StringConverter.Convert(WeatherLocality!.Latitude));
        dict.AddIfValueNotNull("lon", StringConverter.Convert(WeatherLocality!.Longitude));
        dict.AddIfValueNotNull("lang", WeatherLocale?.Locale);
        FillRequestParams(dict);
        return dict;
    }

    private void Validate()
    {
        if (WeatherLocality is null)
            throw new YandexWeatherApiValidationException("invalid value", nameof(WeatherLocality), WeatherLocality);
    }

    protected virtual void FillRequestParams(IDictionary<string, string> dict)
    {
    }
}
