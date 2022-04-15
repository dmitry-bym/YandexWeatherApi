namespace YandexWeatherApi;

internal sealed class YandexWeatherRequestCreator : IYandexWeatherRequestCreator
{
    private readonly IYandexWeatherClient _weatherClient;

    internal YandexWeatherRequestCreator(IYandexWeatherClient weatherClient)
    {
        _weatherClient = weatherClient;
    }

    public IYandexWeatherInformersRequest Informers()
    {
        return new YandexWeatherInformersRequest(_weatherClient);
    }

    public IYandexWeatherForecastRequest Forecast()
    {
        return new YandexWeatherForecastRequest(_weatherClient);
    }
}
