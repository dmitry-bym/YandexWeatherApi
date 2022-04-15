namespace YandexWeatherApi.Extensions;

public static class YandexWeatherRequestExtensions
{
    public static T WithLocality<T>(this T request, WeatherLocality locality) where T : IYandexWeatherRequestBase
    {
        request.WeatherLocality = locality;
        return request;
    }

    public static T WithLocality<T>(this T request, double latitude, double longitude) where T : IYandexWeatherRequestBase
    {
        request.WeatherLocality = new WeatherLocality(latitude, longitude);
        return request;
    }

    public static T WithLocale<T>(this T request, WeatherLocale locale) where T : IYandexWeatherRequestBase
    {
        request.WeatherLocale = locale;
        return request;
    }

    public static T WithLimit<T>(this T request, int limit) where T : IYandexWeatherForecastRequest
    {
        request.Limit = limit;
        return request;
    }

    public static T Extra<T>(this T request, bool extra = true) where T : IYandexWeatherForecastRequest
    {
        request.Extra = extra;
        return request;
    }

    public static T Hours<T>(this T request, bool hours = true) where T : IYandexWeatherForecastRequest
    {
        request.Hours = hours;
        return request;
    }
}
