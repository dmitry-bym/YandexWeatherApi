using System.Threading;
using System.Threading.Tasks;
using Moq;
using Xunit;
using YandexWeatherApi.Exceptions;
using YandexWeatherApi.Extensions;
using YandexWeatherApi.Models.InformersModels;

namespace YandexWeatherApi.Tests.Unit;

public class YandexWeatherInformersRequestTest
{
    [Fact]
    public async Task YandexWeatherInformersRequest_Send_AllParametersAreCorrect()
    {
        var client = new Mock<IYandexWeatherClient>();
        var builder = new YandexWeatherInformersRequest(client.Object);
        client.Setup(x => x.Send<InformersResponse>(It.IsAny<YandexWeatherRequest>(), CancellationToken.None))
            .Callback<YandexWeatherRequest, CancellationToken>((request, _) =>
            {
                Assert.Equal("informers", request.Type);
                Assert.Equal("v2", request.ApiVersion);
                Assert.True(request.Params.Count == 3);
                Assert.Equal("12", request.Params["lat"]);
                Assert.Equal("12", request.Params["lon"]);
                Assert.Equal(WeatherLocale.ru_UA.Locale, request.Params["lang"]);
            });
        
        await builder
            .WithLocality(12, 12)
            .WithLocale(WeatherLocale.ru_UA)
            .Send(CancellationToken.None);
        
        client.Verify(x => x.Send<InformersResponse>(It.IsAny<YandexWeatherRequest>(), CancellationToken.None), Times.Once);
    }
    
    [Fact]
    public async Task YandexWeatherInformersRequest_SendWithoutLocality_Throws()
    {
        var client = new Mock<IYandexWeatherClient>();
        var builder = new YandexWeatherInformersRequest(client.Object);

        await Assert.ThrowsAsync<YandexWeatherApiValidationException>(() => builder.Send(CancellationToken.None));
    }
}
