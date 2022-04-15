namespace YandexWeatherApi.Result;

public class SuccessResult<T> : Result<T>
{
    internal SuccessResult(T data) : base(data, null, true)
    { }
}
