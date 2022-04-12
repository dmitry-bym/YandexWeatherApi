namespace YandexWeatherApi;

public interface IWeatherRequest
{
    public string ApiVersion { get; }
    
    public string Type { get; }
    
    public IEnumerable<(string, string)> Params { get; }
}

public interface IWeatherRequest<T> : IWeatherRequest
{
}