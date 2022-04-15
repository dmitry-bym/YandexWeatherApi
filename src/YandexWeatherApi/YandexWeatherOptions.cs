using Microsoft.Extensions.Logging;

namespace YandexWeatherApi;

/// <summary>
/// Represent options for weather service
/// </summary>
public class YandexWeatherOptions
{
    /// <summary>
    /// Api key. Required.
    /// </summary>
    public string? ApiKey { get; set; }
    
    /// <summary>
    /// Custom logger. Optional.
    /// </summary>
    public ILogger? Logger { get; set; }
    
    /// <summary>
    /// Custom <c>IHttpClientFactory</c>. Optional.
    /// </summary>
    public IHttpClientFactory? ClientFactory { get; set; }
    
    /// <summary>
    /// Custom http client. Optional.
    /// </summary>
    public HttpClient? Client { get; set; }
}
