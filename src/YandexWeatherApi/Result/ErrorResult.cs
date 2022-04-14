namespace YandexWeatherApi.Result;

public class ErrorResult<T> : Result<T>
{
    internal ErrorResult(string message) : base(default, message, false)
    { }
}