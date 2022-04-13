using System.Text.Json;

namespace YandexWeatherApi;

public class YandexWeatherService : IYandexWeatherService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly WeatherServiceSettings _serviceSettings;
    private const string ApiKeyHeaderName = "X-Yandex-API-Key";
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

    public async Task<Result<TResponse>> Send<TResponse>(IWeatherRequest request, CancellationToken ct)
    {
        using var client = _clientFactory.CreateClient();
        client.DefaultRequestHeaders.Add(ApiKeyHeaderName, _serviceSettings.ApiKey);
        
        using var response = await client.GetAsync(CreateUri(request), ct).ConfigureAwait(false);
        var stream = await response.Content.ReadAsStreamAsync(ct).ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
            return new ErrorResult<TResponse>("error"); //todo
        
        var data = JsonSerializer.Deserialize<TResponse>(stream)!;
        return new SuccessResult<TResponse>(data);
    }

    private string CreateUri(IWeatherRequest request)
    {
        //todo
        return "";
    }
}