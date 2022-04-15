# YandexWeatherApi
Wrapper for Yandex Weather API.

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
```
Or
```c#
request.WithLocale(WeatherLocale.be_BY);
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
        var a = await _requestCreator.Forecast()
            .Extra()
            .WithLocality(55, 21)
            .Send(ct);
        
        return a.Data;
    }
```
