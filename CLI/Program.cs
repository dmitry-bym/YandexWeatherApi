// See https://aka.ms/new-console-template for more information

using YandexWeatherApi;

Console.WriteLine("Hello, World!");

var a = await new YandexWeatherServiceBuilder()
    .UseApiKey("")
    .Build()
    .Informers()
    .WithLocality("55.04494", "21.67671")
    .Send(CancellationToken.None);

Console.WriteLine(a.Data.Info.Url);
