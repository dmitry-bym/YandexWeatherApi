namespace YandexWeatherApi;

public static class YandexWeatherInformersRequestBuilderExtensions
{
    public static YandexWeatherInformersRequestBuilder WithLocality(this YandexWeatherInformersRequestBuilder builder, WeatherLocality locality)
    {
        builder.WeatherLocality = locality;
        return builder;
    }
    
    public static YandexWeatherInformersRequestBuilder WithLocality(this YandexWeatherInformersRequestBuilder builder, string latitude, string longitude)
    {
        builder.WeatherLocality = new WeatherLocality(latitude, longitude);
        return builder;
    }
    
    public static YandexWeatherInformersRequestBuilder WithLocale(this YandexWeatherInformersRequestBuilder builder, WeatherLocale locale)
    {
        builder.WeatherLocale = locale;
        return builder;
    }
}
