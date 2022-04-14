using System.Threading;
using System.Threading.Tasks;
using Moq;
using Xunit;
using YandexWeatherApi.Exceptions;
using YandexWeatherApi.Extensions;
using YandexWeatherApi.Models.ForecastModels;

namespace YandexWeatherApi.Tests.Unit;

public class YandexWeatherForecastRequestTests
{
    [Fact]
    public async Task YandexWeatherForecastRequest_Send_AllParametersAreCorrect()
    {
        var client = new Mock<IYandexWeatherClient>();
        var builder = new YandexWeatherForecastRequest(client.Object);
        client.Setup(x => x.Send<ForecastResponse>(It.IsAny<YandexWeatherRequest>(), CancellationToken.None))
            .Callback<YandexWeatherRequest, CancellationToken>((request, _) =>
            {
                Assert.Equal("forecast", request.Type);
                Assert.Equal("v2", request.ApiVersion);
                Assert.True(request.Params.Count == 6);
                Assert.Equal("12", request.Params["lat"]);
                Assert.Equal("12", request.Params["lon"]);
                Assert.Equal("true", request.Params["extra"]);
                Assert.Equal("true", request.Params["hours"]);
                Assert.Equal("12", request.Params["limit"]);
                Assert.Equal(WeatherLocale.ru_UA.Locale, request.Params["lang"]);
            });
        
        await builder
            .Extra()
            .Hours()
            .WithLimit(12)
            .WithLocality(12, 12)
            .WithLocale(WeatherLocale.ru_UA)
            .Send(CancellationToken.None);
        
        client.Verify(x => x.Send<ForecastResponse>(It.IsAny<YandexWeatherRequest>(), CancellationToken.None), Times.Once);
    }
    
    [Fact]
    public async Task YandexWeatherForecastRequest_SendWithoutExtra_AllParametersAreCorrect()
    {
        var client = new Mock<IYandexWeatherClient>();
        var builder = new YandexWeatherForecastRequest(client.Object);
        client.Setup(x => x.Send<ForecastResponse>(It.IsAny<YandexWeatherRequest>(), CancellationToken.None))
            .Callback<YandexWeatherRequest, CancellationToken>((request, _) =>
            {
                Assert.Equal("forecast", request.Type);
                Assert.Equal("v2", request.ApiVersion);
                Assert.True(request.Params.Count == 4);
                Assert.Equal("12", request.Params["lat"]);
                Assert.Equal("12", request.Params["lon"]);
                Assert.Equal("12", request.Params["limit"]);
                Assert.Equal(WeatherLocale.ru_UA.Locale, request.Params["lang"]);
            });
        
        await builder
            .WithLimit(12)
            .WithLocality(12, 12)
            .WithLocale(WeatherLocale.ru_UA)
            .Send(CancellationToken.None);
        
        client.Verify(x => x.Send<ForecastResponse>(It.IsAny<YandexWeatherRequest>(), CancellationToken.None), Times.Once);
    }
    
    [Fact]
    public async Task YandexWeatherInformersRequest_SendWithoutLocality_Throws()
    {
        var client = new Mock<IYandexWeatherClient>();
        var builder = new YandexWeatherForecastRequest(client.Object);
        
        await Assert.ThrowsAsync<YandexWeatherApiValidationException>(() => builder.Send(CancellationToken.None));
    }
}
