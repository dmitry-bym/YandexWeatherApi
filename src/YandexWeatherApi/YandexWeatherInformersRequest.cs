using YandexWeatherApi.Models.InformersModels;

namespace YandexWeatherApi;

internal sealed class YandexWeatherInformersRequest : YandexWeatherRequestBase<InformersResponse>, IYandexWeatherInformersRequest
{
    protected override string WeatherType => "informers";
    protected override string ApiVersion => "v2";
    internal YandexWeatherInformersRequest(IYandexWeatherClient weatherService) : base(weatherService)
    { }
}
