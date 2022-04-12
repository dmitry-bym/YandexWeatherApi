using System.Text.Json;

namespace YandexWeatherApi;

public class YandexWeatherService : IYandexWeatherService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly WeatherServiceSettings _serviceSettings;
    public YandexWeatherService(IHttpClientFactory clientFactory, WeatherServiceSettings serviceSettings)
    {
        _clientFactory = clientFactory;
        _serviceSettings = serviceSettings;
    }

    public YandexWeatherInformersRequestBuilder Informers()
    {
        return new YandexWeatherInformersRequestBuilder(this);
    }

    public void Forecast()
    {
        //todo
    }

    public async Task<TResponse> Send<TResponse>(IWeatherRequest request, CancellationToken ct)
    {
        using var client = _clientFactory.CreateClient();
        client.DefaultRequestHeaders.Add("X-Yandex-API-Key", _serviceSettings.ApiKey);
        
        using var response = await client.GetAsync(CreateUri(request), ct).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        var stream = await response.Content.ReadAsStreamAsync(ct).ConfigureAwait(false);
        return JsonSerializer.Deserialize<TResponse>(stream)!;
    }

    private string CreateUri(IWeatherRequest request)
    {
        //todo
        return "";
    }
}