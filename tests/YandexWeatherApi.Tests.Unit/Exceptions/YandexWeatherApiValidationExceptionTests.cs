using Xunit;
using YandexWeatherApi.Exceptions;

namespace YandexWeatherApi.Tests.Unit.Exceptions;

public class YandexWeatherApiValidationExceptionTests
{
    [Fact]
    public void YandexWeatherApiValidationException_CreateMessage_MessageFormatCorrect()
    {
        var expected = "message Name: name, value: value";
        var exception = new YandexWeatherApiValidationException("message", "name", "value");

        Assert.Equal(expected, exception.Message);
    }
}
