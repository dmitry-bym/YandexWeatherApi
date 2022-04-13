namespace YandexWeatherApi.Result;

public abstract class Result
{
    protected Result(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }
    public bool IsSuccess { get; }
    
    public bool IsFail => !IsSuccess;
}

public abstract class Result<T> : Result
{
    private readonly T? _data;
    
    private readonly string? _error;

    protected Result(T? data, string? error, bool isSuccess): base(isSuccess)
    {
        _data = data;
        _error = error;
    }

    public T? DataOrDefault => _data;
    
    public T Data => _data ?? throw new NotImplementedException();
    
    public string Error => _error ?? throw new NotImplementedException();
    
    public string? ErrorOrDefault => _error;
}