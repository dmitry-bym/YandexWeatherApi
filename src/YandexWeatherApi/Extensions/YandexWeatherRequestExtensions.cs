namespace YandexWeatherApi.Extensions;

public static class YandexWeatherRequestExtensions
{
    public static T WithLocality<T>(this T builder, WeatherLocality locality) where T : IYandexWeatherRequestBase
    {
        builder.WeatherLocality = locality;
        return builder;
    }

    public static T WithLocality<T>(this T builder, string latitude, string longitude) where T : IYandexWeatherRequestBase
    {
        builder.WeatherLocality = new WeatherLocality(latitude, longitude);
        return builder;
    }

    public static T WithLocale<T>(this T builder, WeatherLocale locale) where T : IYandexWeatherRequestBase
    {
        builder.WeatherLocale = locale;
        return builder;
    }

    public static T WithLimit<T>(this T builder, int limit) where T : IYandexWeatherForecastRequest
    {
        builder.Limit = limit;
        return builder;
    }

    public static T Extra<T>(this T builder, bool extra = true) where T : IYandexWeatherForecastRequest
    {
        builder.Extra = extra;
        return builder;
    }

    public static T Hours<T>(this T builder, bool hours = true) where T : IYandexWeatherForecastRequest
    {
        builder.Extra = hours;
        return builder;
    }
}
