using System.Text.Json;

namespace YandexWeatherApi;

internal class YandexWeatherService : IYandexWeatherService, IYandexWeatherClient
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly WeatherServiceSettings _serviceSettings;
    private const string ApiKeyHeaderName = "X-Yandex-API-Key";

    internal YandexWeatherService(IHttpClientFactory clientFactory, WeatherServiceSettings serviceSettings)
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
        //todo implement forecast request
    }

    //todo move to sender or client
    public async Task<Result<TResponse>> Send<TResponse>(IWeatherRequest request, CancellationToken ct)
    {
        using var client = _clientFactory.CreateClient();
        client.DefaultRequestHeaders.Add(ApiKeyHeaderName, _serviceSettings.ApiKey);

        using var response = await client.GetAsync(CreateUri(request), ct).ConfigureAwait(false);
        var stream = await response.Content.ReadAsStringAsync(ct).ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
            return new ErrorResult<TResponse>("error"); //todo

        var data = JsonSerializer.Deserialize<TResponse>(stream)!;
        return new SuccessResult<TResponse>(data);
    }

    private string CreateUri(IWeatherRequest request)
    {
        var parameters = request.Params.Select(x => $"{x.Item1}={x.Item2}").StringJoin('&');

        return $"https://api.weather.yandex.ru/{request.ApiVersion}/{request.Type}?{parameters}";
    }
}