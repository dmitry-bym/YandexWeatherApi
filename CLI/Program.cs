// See https://aka.ms/new-console-template for more information

using YandexWeatherApi;

Console.WriteLine("Hello, World!");

var a = await new YandexWeatherServiceBuilder()
    .Build()
    .Informers()
    .WithLocality("11", "11")
    .Send(CancellationToken.None);
