using YandexWeatherApi.Models.ForecastModels;

namespace YandexWeatherApi;

public interface IYandexWeatherForecastRequest : IYandexWeatherRequestBase<ForecastResponse>
{
    /// <summary>
    /// . Optional.
    /// </summary>
    int? Limit { get; set; }
    
    /// <summary>
    /// . Optional.
    /// </summary>
    bool? Hours { get; set; }
    
    /// <summary>
    /// . Optional.
    /// </summary>
    bool? Extra { get; set; }
}