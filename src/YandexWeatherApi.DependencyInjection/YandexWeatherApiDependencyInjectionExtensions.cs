using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace YandexWeatherApi.DependencyInjection;

public static class YandexWeatherApiDependencyInjectionExtensions
{
    public static IServiceCollection AddYandexWeather(this IServiceCollection services, Action<YandexWeatherOptions> configureOptions)
    {
        var weatherService = new YandexWeatherServiceBuilder()
            .Configure(configureOptions)
            .Build();
        
        services.AddSingleton<IYandexWeatherService, YandexWeatherService>(_ => weatherService);
        return services;
    }
}

