using Xunit;

namespace YandexWeatherApi.Tests.Unit;

public class YandexWeatherTests
{
    [Fact]
    public void YandexWeather_CreateBuilder_Success()
    {
        var builder = YandexWeather.CreateBuilder();
        Assert.True(builder is YandexWeatherServiceBuilder);
    }
}
