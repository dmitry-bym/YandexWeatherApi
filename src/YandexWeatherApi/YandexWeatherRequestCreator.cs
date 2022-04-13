namespace YandexWeatherApi;

internal sealed class YandexWeatherRequestCreator : IYandexWeatherRequestCreator
{
    private readonly IYandexWeatherClient _weatherClient;

    internal YandexWeatherRequestCreator(IYandexWeatherClient weatherClient)
    {
        _weatherClient = weatherClient;
    }

    public YandexWeatherInformersRequest Informers()
    {
        return new YandexWeatherInformersRequest(_weatherClient);
    }

    public YandexWeatherForecastRequest Forecast()
    {
        return new YandexWeatherForecastRequest(_weatherClient);
    }
}
