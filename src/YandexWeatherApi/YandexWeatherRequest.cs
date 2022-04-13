namespace YandexWeatherApi;

internal class YandexWeatherRequest
{
    public YandexWeatherRequest(string apiVersion, string type, IDictionary<string, string> @params)
    {
        ApiVersion = apiVersion;
        Type = type;
        Params = @params;
    }

    public string ApiVersion { get; }
    public string Type { get; }
    public IDictionary<string, string> Params { get; }
}
