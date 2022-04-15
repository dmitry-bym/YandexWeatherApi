using YandexWeatherApi.Result;

namespace YandexWeatherApi;

internal interface IYandexWeatherClient
{
    Task<Result<TResponse>> Send<TResponse>(YandexWeatherRequest request, CancellationToken ct);
}
