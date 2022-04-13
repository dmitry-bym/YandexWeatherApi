using Microsoft.Extensions.Logging;

namespace YandexWeatherApi.Extensions;

public static class YandexWeatherServiceBuilderExtensions
{
    public static YandexWeatherServiceBuilder UseHttpClientFactory(this YandexWeatherServiceBuilder builder, IHttpClientFactory clientFactory)
    {
        return builder.Configure(x => x.ClientFactory = clientFactory);
    }
    
    public static YandexWeatherServiceBuilder UseHttpClient(this YandexWeatherServiceBuilder builder, HttpClient client)
    {
        return builder.Configure(x => x.Client = client);
    }
    
    public static YandexWeatherServiceBuilder UseLogger(this YandexWeatherServiceBuilder builder, ILogger logger)
    {
        return builder.Configure(x => x.Logger = logger);
    }
    
    public static YandexWeatherServiceBuilder UseApiKey(this YandexWeatherServiceBuilder builder, string apiKey)
    {
        return builder.Configure(x => x.ApiKey = apiKey);
    }
}
