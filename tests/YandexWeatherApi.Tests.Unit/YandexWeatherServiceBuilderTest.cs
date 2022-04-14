using System.Net.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using YandexWeatherApi.Exceptions;
using YandexWeatherApi.Extensions;

namespace YandexWeatherApi.Tests.Unit;

public class YandexWeatherServiceBuilderTest
{
    [Fact]
    public void YandexWeatherServiceBuilder_BuildWithoutApiKey_Throws()
    {
        var builder = new YandexWeatherServiceBuilder();
        Assert.Throws<YandexWeatherApiValidationException>(builder.Build);
    }
    
    [Fact]
    public void YandexWeatherServiceBuilder_BuildWithClientAndFactory_Throws()
    {
        var builder = new YandexWeatherServiceBuilder();
        var factory = new Mock<IHttpClientFactory>().Object;
        
        builder.UseApiKey("asdasdaasd")
            .UseHttpClient(new HttpClient())
            .UseHttpClientFactory(factory);

        Assert.Throws<YandexWeatherApiConflictException>(builder.Build);
    }
    
    [Fact]
    public void YandexWeatherServiceBuilder_BuildWithKey_Success()
    {
        var builder = new YandexWeatherServiceBuilder();
        builder.UseApiKey("asdasdaasd").Build();
    }
    
    [Fact]
    public void YandexWeatherServiceBuilder_BuildWithKeyAndFactory_Success()
    {
        var builder = new YandexWeatherServiceBuilder();
        var factory = new Mock<IHttpClientFactory>().Object;
        
        builder
            .UseApiKey("asdasdaasd")
            .UseHttpClientFactory(factory)
            .Build();
    }
    
    [Fact]
    public void YandexWeatherServiceBuilder_BuildWithKeyAndClientAndLogger_Success()
    {
        var builder = new YandexWeatherServiceBuilder();
        var logger = new Mock<ILogger>().Object;
        
        builder
            .UseApiKey("asdasdaasd")
            .UseLogger(logger)
            .UseHttpClient(new HttpClient())
            .Build();
    }
}
