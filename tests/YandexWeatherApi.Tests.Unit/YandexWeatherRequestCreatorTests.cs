using Moq;
using Xunit;

namespace YandexWeatherApi.Tests.Unit;

public class YandexWeatherRequestCreatorTests
{
    [Fact]
    public void YandexWeatherRequestCreator_Forecast_Success()
    {
        var client = new Mock<IYandexWeatherClient>().Object;
        var creator = new YandexWeatherRequestCreator(client);
        creator.Forecast();
    }
    
    [Fact]
    public void YandexWeatherRequestCreator_Informers_Success()
    {
        var client = new Mock<IYandexWeatherClient>().Object;
        var creator = new YandexWeatherRequestCreator(client);
        creator.Informers();
    }
}
