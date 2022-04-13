namespace YandexWeatherApi;

public interface IWeatherRequest
{
    string ApiVersion { get; }
    
    string Type { get; }
    
    IEnumerable<(string, string)> Params { get; }
}