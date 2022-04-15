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
    /// <summary>
    /// Make and send request to Yandex Weather api.
    /// </summary>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>Result of request. Contains success value or error.</returns>
    Task<Result<TResponse>> Send(CancellationToken ct);
}
