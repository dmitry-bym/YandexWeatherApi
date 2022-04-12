namespace YandexWeatherApi;

public interface IYandexWeatherService
{
    YandexWeatherInformersRequestBuilder Informers();
    void Forecast();
    Task<TResponse> Send<TResponse>(IWeatherRequest request, CancellationToken ct);
}