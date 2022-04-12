using YandexWeatherApi.Models;

namespace YandexWeatherApi;

public class YandexWeatherRequest : IWeatherRequest
{
    public YandexWeatherRequest(string apiVersion, string type, IEnumerable<(string, string)> @params)
    {
        ApiVersion = apiVersion;
        Type = type;
        Params = @params;
    }

    public string ApiVersion { get; }
    public string Type { get; }
    public IEnumerable<(string, string)> Params { get; }
}
