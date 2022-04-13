using YandexWeatherApi.Helpers;
using YandexWeatherApi.Models.ForecastModels;

namespace YandexWeatherApi;

public sealed class YandexWeatherForecastRequest : YandexWeatherRequestBase<ForecastResponse>
{
    protected override string WeatherType => "forecast";
    protected override string ApiVersion => "v2";
    
    internal YandexWeatherForecastRequest(IYandexWeatherClient weatherService) : base(weatherService)
    { }

    public int? Limit { get; set; } = 1;

    public bool? Hours { get; set; } = true;

    public bool? Extra { get; set; } = true;
    

    protected override void FillRequestParams(IDictionary<string, string> dict)
    {
        dict.AddIfValueNotNull("limit", Limit);
        dict.AddIfValueNotNull("hours", Hours);
        dict.AddIfValueNotNull("extra", Extra);
    }
}
