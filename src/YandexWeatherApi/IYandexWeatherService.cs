namespace YandexWeatherApi;

public interface IYandexWeatherService
{
    YandexWeatherInformersRequestBuilder Informers();
    void Forecast();
    Task<Result<TResponse>> Send<TResponse>(IWeatherRequest request, CancellationToken ct);
}