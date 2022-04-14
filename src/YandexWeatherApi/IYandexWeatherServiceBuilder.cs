namespace YandexWeatherApi;

public interface IYandexWeatherServiceBuilder
{
    IYandexWeatherServiceBuilder Configure(Action<YandexWeatherOptions> configureOptions);
    IYandexWeatherRequestCreator Build();
}
