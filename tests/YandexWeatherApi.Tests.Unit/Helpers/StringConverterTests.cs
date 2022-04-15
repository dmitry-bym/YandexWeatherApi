using YandexWeatherApi.Helpers;
using Xunit;

namespace YandexWeatherApi.Tests.Unit.Helpers;

public class StringConverterTests
{
    [Theory]
    [InlineData(true, "true")]
    [InlineData(false, "false")]
    [InlineData(null, null)]
    public void StringConverter_ConvertBool(bool? value, string? expected)
    {
        var result = StringConverter.Convert(value);
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(12, "12")]
    [InlineData(31454, "31454")]
    [InlineData(-123, "-123")]
    [InlineData(null, null)]
    public void StringConverter_ConvertInt(int? value, string? expected)
    {
        var result = StringConverter.Convert(value);
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(12.0123, "12.0123")]
    [InlineData(01.01230000, "1.0123")]
    [InlineData(99.00000, "99")]
    [InlineData(0.000, "0")]
    [InlineData(1, "1")]
    [InlineData(null, null)]
    public void StringConverter_ConvertDouble(double? value, string? expected)
    {
        var result = StringConverter.Convert(value);
        Assert.Equal(expected, result);
    }
}
