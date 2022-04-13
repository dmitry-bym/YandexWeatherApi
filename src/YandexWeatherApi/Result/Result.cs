using System.Data;

namespace YandexWeatherApi.Result;

public abstract class Result
{
    protected Result(bool success)
    {
        Success = success;
    }
    public bool Success { get; }
    
    public bool Fail => !Success;
}

public abstract class Result<T> : Result
{
    private readonly T? _data;
    
    private readonly string? _error;

    protected Result(T? data, string? error, bool success): base(success)
    {
        _data = data;
        _error = error;
    }

    public T? DataOrDefault => _data;
    
    public T Data => _data ?? throw new NotImplementedException();
    
    public string Error => _error ?? throw new NotImplementedException();
    
    public string? ErrorOrDefault => _error;
}