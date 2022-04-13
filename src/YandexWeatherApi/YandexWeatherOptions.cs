using Microsoft.Extensions.Logging;

namespace YandexWeatherApi;

public class YandexWeatherOptions
{
    public string? ApiKey { get; set; }
    
    public ILogger? Logger { get; set; }
    
    public IHttpClientFactory? ClientFactory { get; set; }
    
    public HttpClient? Client { get; set; }
}
