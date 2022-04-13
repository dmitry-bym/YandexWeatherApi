using YandexWeatherApi.Result;

namespace YandexWeatherApi;

public interface IYandexWeatherClient
{
    Task<Result<TResponse>> Send<TResponse>(YandexWeatherRequest request, CancellationToken ct);
}
