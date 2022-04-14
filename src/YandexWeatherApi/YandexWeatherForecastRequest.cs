using YandexWeatherApi.Helpers;
using YandexWeatherApi.Models.ForecastModels;

namespace YandexWeatherApi;

internal sealed class YandexWeatherForecastRequest : YandexWeatherRequestBase<ForecastResponse>, IYandexWeatherForecastRequest
{
    protected override string WeatherType => "forecast";
    protected override string ApiVersion => "v2";
    
    internal YandexWeatherForecastRequest(IYandexWeatherClient weatherService) : base(weatherService)
    { }

    public int? Limit { get; set; }

    public bool? Hours { get; set; }

    public bool? Extra { get; set; }

    protected override void FillRequestParams(IDictionary<string, string> dict)
    {
        dict.AddIfValueNotNull("limit", Limit.ToString());
        dict.AddIfValueNotNull("hours", ConvertBool(Hours));
        dict.AddIfValueNotNull("extra", ConvertBool(Extra));
    }

    private string? ConvertBool(bool? value) //todo move to helper
    {
        if (!value.HasValue)
            return null;
        
        return value.Value ? "true" : "false";
    }
}
