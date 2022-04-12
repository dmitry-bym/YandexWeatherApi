using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace YandexWeatherApi.DependencyInjection;

public static class YandexWeatherApiDependencyInjectionExtensions
{
    public static IServiceCollection AddYandexWeather(this IServiceCollection services, Action<YandexWeatherOptions> configureOptions)
    {
        var options = new YandexWeatherOptions();
        configureOptions(options);
        services.AddSingleton<IYandexWeatherService, YandexWeatherService>();
    }
}

public class YandexWeatherOptions
{
    public string ApiKey { get; set; }
    
    public ILogger Logger { get; set; }
    
    public IHttpClientFactory ClientFactory { get; set; }
}
