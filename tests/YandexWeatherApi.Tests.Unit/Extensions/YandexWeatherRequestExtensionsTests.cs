using Moq;
using Xunit;
using YandexWeatherApi.Extensions;

namespace YandexWeatherApi.Tests.Unit.Extensions;

public class YandexWeatherRequestExtensionsTests
{
    [Fact]
    public void YandexWeatherRequestExtensions_WithLocality_SuccessfullySet()
    {
        var locality = new WeatherLocality(12, 12);
        var requestBase = new Mock<IYandexWeatherRequestBase>();
        requestBase.SetupProperty(x => x.WeatherLocality);

        requestBase.Object.WithLocality(locality);
        
        Assert.Equal(locality, requestBase.Object.WeatherLocality);
    }
    
    [Fact]
    public void YandexWeatherRequestExtensions_WithLocalityOverload_SuccessfullySet()
    {
        var locality = new WeatherLocality(12, 12);
        var requestBase = new Mock<IYandexWeatherRequestBase>();
        requestBase.SetupProperty(x => x.WeatherLocality);

        requestBase.Object.WithLocality(12, 12);
        
        Assert.Equal(locality, requestBase.Object.WeatherLocality);
    }
    
    [Fact]
    public void YandexWeatherRequestExtensions_WithLocale_SuccessfullySet()
    {
        var requestBase = new Mock<IYandexWeatherRequestBase>();
        requestBase.SetupProperty(x => x.WeatherLocale);

        requestBase.Object.WithLocale(WeatherLocale.be_BY);
        
        Assert.Equal(WeatherLocale.be_BY, requestBase.Object.WeatherLocale);
    }
    
    [Fact]
    public void YandexWeatherRequestExtensions_WithLimit_SuccessfullySet()
    {
        var limit = 12;
        var requestBase = new Mock<IYandexWeatherForecastRequest>();
        requestBase.SetupProperty(x => x.Limit);

        requestBase.Object.WithLimit(limit);
        
        Assert.Equal(limit, requestBase.Object.Limit);
    }
    
    [Fact]
    public void YandexWeatherRequestExtensions_WithExtra_SetTrue()
    {
        var requestBase = new Mock<IYandexWeatherForecastRequest>();
        requestBase.SetupProperty(x => x.Extra);

        requestBase.Object.Extra();
        
        Assert.True(requestBase.Object.Extra);
    }
    
    [Fact]
    public void YandexWeatherRequestExtensions_WithHours_SetTrue()
    {
        var requestBase = new Mock<IYandexWeatherForecastRequest>();
        requestBase.SetupProperty(x => x.Hours);

        requestBase.Object.Hours();
        
        Assert.True(requestBase.Object.Hours);
    }
}
