namespace YandexWeatherApi.Extensions;

public static class YandexWeatherRequestExtensions
{
    public static T WithLocality<T>(this T builder, WeatherLocality locality) where T : YandexWeatherRequestBase
    {
        builder.WeatherLocality = locality;
        return builder;
    }

    public static T WithLocality<T>(this T builder, string latitude, string longitude) where T : YandexWeatherRequestBase
    {
        builder.WeatherLocality = new WeatherLocality(latitude, longitude);
        return builder;
    }

    public static T WithLocale<T>(this T builder, WeatherLocale locale) where T : YandexWeatherRequestBase
    {
        builder.WeatherLocale = locale;
        return builder;
    }
}
