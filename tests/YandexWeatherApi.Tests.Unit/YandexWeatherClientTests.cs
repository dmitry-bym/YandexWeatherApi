using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Xunit;
using YandexWeatherApi.Exceptions;
using YandexWeatherApi.Result;

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
    
    [Fact]
    public async Task YandexWeatherClient_ClientSend_ErrorResult()
    {
        var result = await YandexWeatherClient_Send_Success((handler, key) => new YandexWeatherClient(null, new HttpClient(handler), null, key), "{}", HttpStatusCode.InternalServerError);
        Assert.True(result.IsFail);
    }

    [Fact]
    public async Task YandexWeatherClient_ClientSend_SuccessResult()
    {
        var result = await YandexWeatherClient_Send_Success((handler, key) => new YandexWeatherClient(null, new HttpClient(handler), null, key), "{\"result\" : \"success\"}", HttpStatusCode.OK);
        Assert.True(result.IsSuccess);
        Assert.Equal("success", result.Data.Result);
    }
    
    [Fact]
    public async Task YandexWeatherClient_FactorySend_SuccessResult()
    {
        var result = await YandexWeatherClient_Send_Success((handler, key) =>
        {
            var factory = new Mock<IHttpClientFactory>();
            factory.Setup(x => x.CreateClient(It.IsAny<string>()))
                .Returns(new HttpClient(handler));
            
            factory.Setup(x => x.CreateClient(It.IsAny<string>()))
                .Returns(new HttpClient(handler));
            
            return new YandexWeatherClient(factory.Object, null, null, key);
        }, "{\"result\" : \"success\"}", HttpStatusCode.OK);
        
        
        Assert.True(result.IsSuccess);
        Assert.Equal("success", result.Data.Result);
    }
    
    private async Task<Result<Response>> YandexWeatherClient_Send_Success(Func<HttpMessageHandler, string, YandexWeatherClient> factory, string response, HttpStatusCode code)
    {
        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = code,
                Content = new StringContent(response)
            })
            .Callback<HttpRequestMessage, CancellationToken>((message, _) =>
            {
                Assert.Equal("key", message.Headers.GetValues("X-Yandex-API-Key").First());
                Assert.Equal(new Uri("https://api.weather.yandex.ru/v1/type?param1=value1&param2=value2&param3=value3"), message.RequestUri);
            })
            .Verifiable();

        handlerMock
            .Protected()
            .Setup("Dispose", ItExpr.IsAny<bool>());

        var client = factory(handlerMock.Object, "key");

        var param = new Dictionary<string, string>
        {
            { "param1", "value1" },
            { "param2", "value2" },
            { "param3", "value3" }
        };
        
        var request = new YandexWeatherRequest("v1", "type", param);
        return await client.Send<Response>(request, CancellationToken.None);
    }
    

    private class Response
    {
        [JsonPropertyName("result")]
        public string? Result { get; set; }
    }
}
