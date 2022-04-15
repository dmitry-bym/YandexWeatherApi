namespace YandexWeatherApi.Exceptions;

public abstract class YandexWeatherApiException : Exception
{
    protected YandexWeatherApiException(string? message) : base(message)
    {
    }
}