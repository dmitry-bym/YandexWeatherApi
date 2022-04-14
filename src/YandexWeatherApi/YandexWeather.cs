namespace YandexWeatherApi;

public static class YandexWeather
{
    /// <summary>
    /// Create new instance of <c>YandexWeatherServiceBuilder</c>
    /// </summary>
    public static YandexWeatherServiceBuilder CreateBuilder()
    {
        return new();
    }
}
