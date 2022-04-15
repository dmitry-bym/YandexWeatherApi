namespace YandexWeatherApi.Exceptions;

public class YandexWeatherApiConflictException : YandexWeatherApiException
{
    internal YandexWeatherApiConflictException(string message) : base(message)
    { }
}