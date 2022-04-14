using Microsoft.Extensions.DependencyInjection;
using YandexWeatherApi.Extensions;

namespace YandexWeatherApi.DependencyInjection;

public static class YandexWeatherApiDependencyInjectionExtensions
{
    public static IServiceCollection AddYandexWeather(this IServiceCollection services, Action<YandexWeatherSettings> configureOptions)
    {
        return services.AddYandexWeather((_, settings) => configureOptions(settings));
    }

    public static IServiceCollection AddYandexWeather(this IServiceCollection services, Action<IServiceProvider, YandexWeatherSettings> configureOptions)
    {
        services.AddSingleton(provider =>
        {
            var weatherSettings = new YandexWeatherSettings();
            configureOptions(provider, weatherSettings);

            var builder = YandexWeather.CreateBuilder()
                .RegisterClient(provider, weatherSettings)
                .Configure(x =>
                {
                    x.Logger = weatherSettings.Logger;
                    x.ApiKey = weatherSettings.ApiKey;
                });

            return builder.Build();
        });

        return services;
    }

    private static IYandexWeatherServiceBuilder RegisterClient(this IYandexWeatherServiceBuilder builder, IServiceProvider serviceProvider, YandexWeatherSettings settings)
    {
        switch (settings.Client, settings.ClientFactory)
        {
            case ({ }, { }):
                break;
            case (_, { }):
                builder.UseHttpClientFactory(settings.ClientFactory);
                break;
            case ({ }, _):
                builder.UseHttpClient(settings.Client);
                break;
            default:
                var factory = serviceProvider.GetService<IHttpClientFactory>();
                if (factory is not null)
                    builder.UseHttpClientFactory(factory);
                break;
        }

        return builder;
    }
}
