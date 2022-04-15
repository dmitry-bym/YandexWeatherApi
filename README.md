# YandexWeatherApi
Wrapper for Yandex Weather API.

## Create a request

```c#
var request = new YandexWeatherServiceBuilder()
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
