namespace YandexWeatherApi.Result;

public class SuccessResult<T> : Result<T>
{
    public SuccessResult(T data) : base(data, null, true)
    { }
}
