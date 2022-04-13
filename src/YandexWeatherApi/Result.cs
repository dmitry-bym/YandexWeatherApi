namespace YandexWeatherApi;

public abstract class Result
{
    public bool Success { get; protected set; }
    public bool Failure => !Success;
}

public abstract class Result<T> : Result
{
    private T _data;

    protected Result(T data)
    {
        Data = data;
    }

    public T Data
    {
        get => Success ? _data : throw new Exception($"You can't access .{nameof(Data)} when .{nameof(Success)} is false");
        set => _data = value;
    }
}

public class SuccessResult : Result
{
    public SuccessResult()
    {
        Success = true;
    }
}

public class SuccessResult<T> : Result<T>
{
    public SuccessResult(T data) : base(data)
    {
        Success = true;
    }
}

public class ErrorResult : Result, IErrorResult
{
    public ErrorResult(string message) : this(message, Array.Empty<Error>())
    {
    }

    public ErrorResult(string message, IReadOnlyCollection<Error> errors)
    {
        Message = message;
        Success = false;
        Errors = errors ?? Array.Empty<Error>();
    }

    public string Message { get; }
    public IReadOnlyCollection<Error> Errors { get; }
}

public class ErrorResult<T> : Result<T>, IErrorResult
{
    public ErrorResult(string message) : this(message, Array.Empty<Error>())
    {    
    }

    public ErrorResult(string message, IReadOnlyCollection<Error> errors) : base(default)
    {
        Message = message;
        Success = false;
        Errors = errors ?? Array.Empty<Error>();
    }

    public string Message { get; set; }
    public IReadOnlyCollection<Error> Errors { get; }
}

public class Error
{
    public Error(string details) : this(null, details)
    {

    }

    public Error(string code, string details)
    {
        Code = code;
        Details = details;
    }

    public string Code { get; }
    public string Details { get; }
}

internal interface IErrorResult
{
    string Message { get; }
    IReadOnlyCollection<Error> Errors { get; }
}


//
// public abstract class Result
// {
//     public virtual bool IsSuccess { get; }
//     public virtual bool IsFail { get; }
//
//     public Result<TResponse> Ok<TResponse>(TResponse response)
//     {
//         return new Result<TResponse>(response, null);
//     }
//     
//     public Result<TResponse> Ok<TResponse>(Error error)
//     {
//         return new Result<TResponse>(default, error);
//     }
// }
//
// public class Result<TResponse> : Result
// {
//     public Result(TResponse? response, Error? error)
//     {
//         ResponseOrDefault = response;
//         ErrorOrDefault = error;
//     }
//     
//     public TResponse? ResponseOrDefault { get; }
//
//     public TResponse Response => ResponseOrDefault!;
//     
//     public Error? ErrorOrDefault { get; }
//     
//     public Error Error => ErrorOrDefault!;
//
//     public override bool IsSuccess => Response is not null;
//     
//     public override bool IsFail => !IsSuccess;
// }
//
// public class Error
// {
//     
// }
