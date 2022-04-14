using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using YandexWeatherApi.Exceptions;
using YandexWeatherApi.Result;

namespace YandexWeatherApi;

internal class YandexWeatherClient : IYandexWeatherClient
{
    private readonly IHttpClientFactory? _clientFactory;
    private readonly HttpClient? _client;
    private readonly ILogger? _logger;
    private readonly string _apiKey;
    
    private const string ApiKeyHeaderName = "X-Yandex-API-Key";
    private static readonly Uri BaseUrl = new("https://api.weather.yandex.ru");
    internal YandexWeatherClient(IHttpClientFactory? clientFactory, HttpClient? client, ILogger? logger, string apiKey)
    {
        if (clientFactory is not null && client is not null)
            throw new YandexWeatherApiConflictException($"Unable to use {nameof(IHttpClientFactory)} and {nameof(HttpClient)} together");

        if (clientFactory is null && client is null)
            throw new YandexWeatherApiConflictException($"There is no {nameof(IHttpClientFactory)} or {nameof(HttpClient)} to send the request");
        
        _logger = logger;
        _client = client;
        _clientFactory = clientFactory;
        _apiKey = apiKey;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public Task<Result<TResponse>> Send<TResponse>(YandexWeatherRequest request, CancellationToken ct)
    {
        return (_clientFactory, _client) switch
        {
            ({ }, { }) => throw new YandexWeatherApiConflictException($"Unable to use {nameof(IHttpClientFactory)} and {nameof(HttpClient)} together"),
            (_, { }) => SendClient<TResponse>(request, ct),
            ({ }, _) => SendFactory<TResponse>(request, ct),
            _ => throw new YandexWeatherApiConflictException($"There is no {nameof(IHttpClientFactory)} or {nameof(HttpClient)} to send the request")
        };
    }

    private Task<Result<TResponse>> SendClient<TResponse>(YandexWeatherRequest request, CancellationToken ct)
    {
        return SendInternal<TResponse>(_client!, request, ct);
    }

    private async Task<Result<TResponse>> SendFactory<TResponse>(YandexWeatherRequest request, CancellationToken ct)
    {
        using var client = _clientFactory!.CreateClient();
        return await SendInternal<TResponse>(client, request, ct).ConfigureAwait(false);
    }

    private async Task<Result<TResponse>> SendInternal<TResponse>(HttpClient client, YandexWeatherRequest request, CancellationToken ct)
    {
        client.DefaultRequestHeaders.Add(ApiKeyHeaderName, _apiKey);
        
        using var response = await client.GetAsync(CreateUri(request), ct).ConfigureAwait(false);
        await using var str = await response.Content.ReadAsStreamAsync(ct).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
            return new ErrorResult<TResponse>($"Status code: {response.StatusCode}. Message: {str}");

        var data = JsonSerializer.Deserialize<TResponse>(str);
        if (data is null)
            return new ErrorResult<TResponse>($"Response can not be deserialized. Status code: {response.StatusCode}. Message: {str}");

        return new SuccessResult<TResponse>(data);
    }

    private string CreateUri(YandexWeatherRequest request) //todo move to uri helper
    {
        var uriBuilder = new UriBuilder(BaseUrl)
        {
            Path = $"{request.ApiVersion}/{request.Type}",
            Query = QueryString.Create(request.Params).ToUriComponent()
        };

        return uriBuilder.ToString();
    }
}
