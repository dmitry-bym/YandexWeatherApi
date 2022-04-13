namespace YandexWeatherApi.Result;

public class ErrorResult<T> : Result<T>
{
    public ErrorResult(string message) : base(default, message, false)
    { }
}