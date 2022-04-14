using System;
using Xunit;
using YandexWeatherApi.Result;

namespace YandexWeatherApi.Tests.Unit.Result;

public class ResultTests
{
    [Fact]
    public void SuccessResult_Create_AllValuesCorrect()
    {
        var data = "success";
        var result = new SuccessResult<string>(data);
        
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFail);
        Assert.Equal(data, result.Data);
        Assert.Equal(data, result.DataOrDefault);
        Assert.Null(result.ErrorOrDefault);
        Assert.Throws<InvalidOperationException>(() => result.Error);
    }
    
    [Fact]
    public void ErrorResult_Create_AllValuesCorrect()
    {
        var error = "error";
        var result = new ErrorResult<string>(error);
        
        Assert.True(result.IsFail);
        Assert.False(result.IsSuccess);
        Assert.Equal(error, result.Error);
        Assert.Equal(error, result.ErrorOrDefault);
        Assert.Null(result.DataOrDefault);
        Assert.Throws<InvalidOperationException>(() => result.Data);
    }
}
