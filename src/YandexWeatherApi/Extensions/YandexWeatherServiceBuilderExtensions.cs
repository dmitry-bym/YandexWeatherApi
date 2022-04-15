using Microsoft.Extensions.Logging;

namespace YandexWeatherApi.Extensions;

public static class YandexWeatherServiceBuilderExtensions
{
    public static IYandexWeatherServiceBuilder UseHttpClientFactory(this IYandexWeatherServiceBuilder builder, IHttpClientFactory clientFactory)
    {
        return builder.Configure(x => x.ClientFactory = clientFactory);
    }
    
    public static IYandexWeatherServiceBuilder UseHttpClient(this IYandexWeatherServiceBuilder builder, HttpClient client)
    {
        return builder.Configure(x => x.Client = client);
    }
    
    public static IYandexWeatherServiceBuilder UseLogger(this IYandexWeatherServiceBuilder builder, ILogger logger)
    {
        return builder.Configure(x => x.Logger = logger);
    }
    
    public static IYandexWeatherServiceBuilder UseApiKey(this IYandexWeatherServiceBuilder builder, string apiKey)
    {
        return builder.Configure(x => x.ApiKey = apiKey);
    }
}
