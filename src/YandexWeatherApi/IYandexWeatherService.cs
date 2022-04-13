namespace YandexWeatherApi;

public interface IYandexWeatherService
{
    YandexWeatherInformersRequestBuilder Informers();
    void Forecast();
}

public interface IYandexWeatherClient
{
    Task<Result<TResponse>> Send<TResponse>(IWeatherRequest request, CancellationToken ct);
}