using YandexWeatherApi.Models.ForecastModels;

namespace YandexWeatherApi;

public interface IYandexWeatherForecastRequest : IYandexWeatherRequestBase<ForecastResponse>
{
    /// <summary>
    /// The number of days in the forecast, including the current day. Optional.
    /// </summary>
    int? Limit { get; set; }
    
    /// <summary>
    /// For each day, the response will contain the hourly weather forecast. Optional. (true by default)
    /// </summary>
    bool? Hours { get; set; }
    
    /// <summary>
    /// Extra information about precipitation. Optional. (false by default)
    /// </summary>
    bool? Extra { get; set; }
}