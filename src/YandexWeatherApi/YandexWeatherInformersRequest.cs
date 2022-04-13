using YandexWeatherApi.Models.InformersModels;

namespace YandexWeatherApi;

public sealed class YandexWeatherInformersRequest : YandexWeatherRequestBase<InformersResponse>
{
    private readonly IYandexWeatherClient _weatherService;
    protected override string WeatherType => "informers";
    protected override string ApiVersion => "v2";
    internal YandexWeatherInformersRequest(IYandexWeatherClient weatherService) : base(weatherService)
    { }
}
