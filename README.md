# YandexWeatherApi C# wrapper
| YandexWeatherApi |  [![nuget](https://img.shields.io/nuget/v/YandexWeatherApi?style=flat-square)](https://www.nuget.org/packages/YandexWeatherApi) [![downloads](https://img.shields.io/nuget/dt/YandexWeatherApi?style=flat-square)](https://www.nuget.org/packages/YandexWeatherApi) [![lisence](https://img.shields.io/badge/lisence-MIT-green?style=flat-square)](https://github.com/dmitry-bym/YandexWeatherApi/blob/master/LICENSE) |
| ------------- |:-------------:|
| __YandexWeatherApi.DependencyInjection__ | [![nuget](https://img.shields.io/nuget/v/YandexWeatherApi.DependencyInjection?style=flat-square)](https://www.nuget.org/packages/YandexWeatherApi.DependencyInjection) [![downloads](https://img.shields.io/nuget/dt/YandexWeatherApi.DependencyInjection?style=flat-square)](https://www.nuget.org/packages/YandexWeatherApi.DependencyInjection) [![lisence](https://img.shields.io/badge/lisence-MIT-green?style=flat-square)](https://github.com/dmitry-bym/YandexWeatherApi/blob/master/LICENSE) |

### Create a request

```c#
var request = YandexWeather.CreateBuilder()
    .UseApiKey("your api key")
    .Build()
    .Forecast(); // or Informers()
```

### Adding parameters
To add parameters you can use extension or set it to fields
```c#
request.WeatherLocale = WeatherLocale.be_BY;
request.Extra = true;
request.Hours = true;
```
Or
```c#
request
    .WithLocale(WeatherLocale.be_BY)
    .Hours()
    .Extra(false)
    .WithLocality(55, 21);
```
    
### Send request
Just call `Send`
```c#
var result = await request.Send(cancellationToken);
```

### Result
Result contains response or error if something goes wrong
```c#
var isSuccess = result.IsSuccess;
var isFail = result.IsFail;

var data = result.Data;                      //throw if error
var dataOrDefault = result.DataOrDefault;    //null if error
var error = result.Error;                    //throw if success 
var errorOrDefault = result.ErrorOrDefault;   //null if success 
```

## YandexWeatherApi.DependencyInjection

```c#
    builder.Services.AddYandexWeather(options =>
    {
        options.ClientFactory = factory
        options.Logger = loger
        options.Client = client
        options.ApiKey = "key";
    });
```
Or you can use service provider to resolve dependencies
```c#
    builder.Services.AddYandexWeather((provider, options) =>
    {
        options.ClientFactory = provider.GetRequiredService<IHttpClientFactory>();
        options.ApiKey = "key";
    });
```
After registration just resolve `IYandexWeatherRequestCreator`
```c#
    private readonly IYandexWeatherRequestCreator _requestCreator;
    public WeatherForecastController(IYandexWeatherRequestCreator requestCreator)
    {
        _requestCreator = requestCreator;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<ForecastResponse> Get(CancellationToken ct)
    {
        var result = await _requestCreator.Forecast()
            .Extra()
            .WithLocality(55, 21)
            .Send(ct);
        
        return result.Data;
    }
```

### Default behaviour
If `HttpClient` and `IHttpClientFactory` wasn't send it will try to resolve `IHttpClientFactory` from Services, if factory wasn't found it will create `new HttpClient()`

## License

Authored by: Dmitry Kaznacheev (dmitry-bym)

This project is under MIT license. You can obtain the license copy [here](https://github.com/dmitry-bym/YandexWeatherApi/blob/master/LICENSE).

This work based on Yandex.Weather API: https://yandex.com/dev/weather
