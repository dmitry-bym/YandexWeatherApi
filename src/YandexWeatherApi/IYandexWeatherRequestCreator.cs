namespace YandexWeatherApi;

public interface IYandexWeatherRequestCreator
{
    YandexWeatherInformersRequest Informers();
    YandexWeatherForecastRequest Forecast();
}