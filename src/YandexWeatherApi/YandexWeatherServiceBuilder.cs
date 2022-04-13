using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;

namespace YandexWeatherApi;

public class YandexWeatherOptions
{
    public string? ApiKey { get; set; }
    
    public ILogger? Logger { get; set; }
    
    public IHttpClientFactory? ClientFactory { get; set; }
}

public class YandexWeatherServiceBuilder
{
    private readonly YandexWeatherOptions _options = new();

    public YandexWeatherServiceBuilder Configure(Action<YandexWeatherOptions> configureOptions)
    {
        configureOptions(_options);
        return this;
    }

    public YandexWeatherServiceBuilder UseHttpClient(HttpClient client)
    {
        if (_options.ClientFactory is not null)
            throw new ArgumentException("Client already configured.", nameof(client));
        
        _options.ClientFactory = new ClientFactory(client);
        return this;
    }
    
    public YandexWeatherServiceBuilder UseHttpClientFactory(IHttpClientFactory clientFactory)
    {
        if (_options.ClientFactory is not null)
            throw new ArgumentException("Client already configured.", nameof(clientFactory));
        
        _options.ClientFactory = clientFactory;
        return this;
    }
    
    public YandexWeatherServiceBuilder UseApiKey(string apiKey)
    {
        _options.ApiKey = apiKey;
        return this;
    }

    public YandexWeatherService Build()
    {
        Validate();
        return new YandexWeatherService(_options.ClientFactory ?? new ClientFactory(new HttpClient()), new WeatherServiceSettings(_options.ApiKey!));
    }
    
    private void Validate()
    {
        if (string.IsNullOrEmpty(_options.ApiKey))
            throw new ValidationException(); //todo correct exception
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
