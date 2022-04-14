namespace YandexWeatherApi;

/// <summary>
/// Allow to create two types of request.
/// </summary>
public interface IYandexWeatherRequestCreator
{
    /// <summary>
    /// Create new instance of informers request.
    /// </summary>
    IYandexWeatherInformersRequest Informers();
    
    /// <summary>
    /// Create new instance of forecast request.
    /// </summary>
    IYandexWeatherForecastRequest Forecast();
}