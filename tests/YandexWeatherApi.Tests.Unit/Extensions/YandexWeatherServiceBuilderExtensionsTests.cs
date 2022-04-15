using System;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using YandexWeatherApi.Extensions;

namespace YandexWeatherApi.Tests.Unit.Extensions;

public class YandexWeatherServiceBuilderExtensionsTests
{
    [Fact]
    public void YandexWeatherServiceBuilderExtensions_ConfigureOptions_SuccessfullySet()
    {
        var client = new HttpClient();
        var apiKey = "apikey";
        var factory = new Mock<IHttpClientFactory>().Object;
        var logger = new Mock<ILogger>().Object;
        
        var options = new YandexWeatherOptions();
        var serviceBuilder = new Mock<IYandexWeatherServiceBuilder>();
        serviceBuilder.Setup(x => x.Configure(It.IsAny<Action<YandexWeatherOptions>>()))
            .Callback<Action<YandexWeatherOptions>>(x =>
            {
                x(options);
            });

        
        serviceBuilder.Object.UseApiKey(apiKey);
        serviceBuilder.Object.UseHttpClient(client);
        serviceBuilder.Object.UseHttpClientFactory(factory);
        serviceBuilder.Object.UseLogger(logger);
        
        Assert.Equal(client, options.Client);
        Assert.Equal(factory, options.ClientFactory);
        Assert.Equal(apiKey, options.ApiKey);
        Assert.Equal(logger, options.Logger);
    }
}
