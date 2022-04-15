using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using YandexWeatherApi.DependencyInjection;
using YandexWeatherApi.Exceptions;

namespace YandexWeatherApi.Tests.Unit;

public class YandexWeatherApiDependencyInjectionExtensionsTests
{
    [Fact]
    public void YandexWeatherApiDependencyInjectionExtensions_WithClientAndFactory_Throws()
    {
        var services = new ServiceCollection();
        var factory = new Mock<IHttpClientFactory>().Object;
        
        services.AddYandexWeather(settings =>
        {
            settings.ApiKey = "aapi key";
            settings.Client = new HttpClient();
            settings.ClientFactory = factory;
        });

        var provider = services.BuildServiceProvider();
        
        Assert.Throws<YandexWeatherApiConflictException>(() => provider.GetService<IYandexWeatherRequestCreator>());
    }
    
    [Fact]
    public void YandexWeatherApiDependencyInjectionExtensions_WithoutClientAndFactory_Success()
    {
        var services = new ServiceCollection();

        services.AddYandexWeather(settings =>
        {
            settings.ApiKey = "aapi key";
        });

        var provider = services.BuildServiceProvider();
        var requestCreator = provider.GetService<IYandexWeatherRequestCreator>();
        
        Assert.NotNull(requestCreator);
    }
    
    [Fact]
    public void YandexWeatherApiDependencyInjectionExtensions_WithClient_Success()
    {
        var services = new ServiceCollection();
        var logger = new Mock<ILogger>().Object;

        services.AddYandexWeather(settings =>
        {
            settings.Logger = logger;
            settings.ApiKey = "aapi key";
            settings.Client = new HttpClient();
        });

        var provider = services.BuildServiceProvider();
        var requestCreator = provider.GetService<IYandexWeatherRequestCreator>();
        
        Assert.NotNull(requestCreator);
    }
    
    [Fact]
    public void YandexWeatherApiDependencyInjectionExtensions_WithFactory_Success()
    {
        var services = new ServiceCollection();
        var factory = new Mock<IHttpClientFactory>().Object;
        services.AddYandexWeather(settings =>
        {
            settings.Logger = null;
            settings.ApiKey = "aapi key";
            settings.ClientFactory = factory;
        });

        var provider = services.BuildServiceProvider();
        var requestCreator = provider.GetService<IYandexWeatherRequestCreator>();
        
        Assert.NotNull(requestCreator);
    }
}
