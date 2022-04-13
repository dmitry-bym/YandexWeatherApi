using Microsoft.Extensions.DependencyInjection;

namespace YandexWeatherApi.DependencyInjection;

public static class YandexWeatherApiDependencyInjectionExtensions
{
    public static IServiceCollection AddYandexWeather(this IServiceCollection services, Action<YandexWeatherOptions> configureOptions)
    {
        var weatherServiceBuilder = new YandexWeatherServiceBuilder()
            .Configure(configureOptions);
        
        weatherServiceBuilder.Validate();

        services.AddSingleton<IYandexWeatherService>(_ => weatherServiceBuilder.Build());
        return services;
    }
}

