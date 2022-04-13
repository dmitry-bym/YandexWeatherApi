using YandexWeatherApi.Result;

namespace YandexWeatherApi;

public interface IYandexWeatherRequestBase
{
    /// <summary>
    /// Weather locality with Latitude and Longitude. Required.
    /// </summary>
    WeatherLocality? WeatherLocality { get; set; }

    /// <summary>
    /// Language of the response. Optional.
    /// </summary>
    WeatherLocale? WeatherLocale { get; set; }
}

public interface IYandexWeatherRequestBase<TResponse> : IYandexWeatherRequestBase
{
    Task<Result<TResponse>> Send(CancellationToken ct);
}
