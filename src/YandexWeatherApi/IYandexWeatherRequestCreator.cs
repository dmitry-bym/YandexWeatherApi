namespace YandexWeatherApi;

public interface IYandexWeatherRequestCreator
{
    IYandexWeatherInformersRequest Informers();
    IYandexWeatherForecastRequest Forecast();
}