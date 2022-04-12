using System.ComponentModel.DataAnnotations;

namespace YandexWeatherApi;

public class YandexWeatherServiceBuilder
{
    private IHttpClientFactory? _clientFactory;
    private string? _apiKey;

    public YandexWeatherServiceBuilder UseHttpClient(HttpClient client)
    {
        if (_clientFactory is not null)
            throw new ArgumentException("Client already configured.", nameof(client));
        
        _clientFactory = new ClientFactory(client);
        return this;
    }
    
    public YandexWeatherServiceBuilder UseHttpClientFactory(IHttpClientFactory clientFactory)
    {
        if (_clientFactory is not null)
            throw new ArgumentException("Client already configured.", nameof(clientFactory));
        
        _clientFactory = clientFactory;
        return this;
    }
    
    public YandexWeatherServiceBuilder UseApiKey(string apiKey)
    {
        _apiKey = apiKey;
        return this;
    }

    public YandexWeatherService Build()
    {
        Validate();
        return new YandexWeatherService(_clientFactory ?? new ClientFactory(new HttpClient()), new WeatherServiceSettings(_apiKey!));
    }
    
    private void Validate()
    {
        if (string.IsNullOrEmpty(_apiKey))
            throw new ValidationException()
    }

    private class ClientFactory : IHttpClientFactory
    {
        private readonly HttpClient _client;

        public ClientFactory(HttpClient client)
        {
            _client = client;
        }
        public HttpClient CreateClient(string name)
        {
            return _client;
        }
    }
}
