using System.Net.Http;
using Moq;
using Xunit;
using YandexWeatherApi.Exceptions;

namespace YandexWeatherApi.Tests.Unit;

public class YandexWeatherClientTests
{
    [Fact]
    public void YandexWeatherClient_CreateWithoutClientAndFactory_Throws()
    {
        var create = () => new YandexWeatherClient(null, null, null, "");
        Assert.Throws<YandexWeatherApiConflictException>(create);
    }
    
    [Fact]
    public void YandexWeatherClient_CreateWithClientAndFactory_Throws()
    {
        var factory = new Mock<IHttpClientFactory>().Object;
        var create = () => new YandexWeatherClient(factory, new HttpClient(), null, "");
        Assert.Throws<YandexWeatherApiConflictException>(create);
    }
}
