using Microsoft.Extensions.DependencyInjection;

namespace YandexWeatherApi.DependencyInjection;

public static class YandexWeatherApiDependencyInjectionExtensions
{
    public static IServiceCollection AddYandexWeather(this IServiceCollection services, Action<YandexWeatherOptions> configureOptions)
    {
        var weatherServiceBuilder = YandexWeather.CreateBuilder()
            .Configure(configureOptions);

        services.AddSingleton(_ => weatherServiceBuilder.Build());
        return services;
    }
}

