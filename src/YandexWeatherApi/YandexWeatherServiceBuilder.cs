using System.ComponentModel.DataAnnotations;

namespace YandexWeatherApi;

public class YandexWeatherServiceBuilder
{
    private readonly YandexWeatherOptions _options = new();

    internal YandexWeatherServiceBuilder()
    {
    }

    public YandexWeatherServiceBuilder Configure(Action<YandexWeatherOptions> configureOptions)
    {
        configureOptions(_options);
        return this;
    }

    public IYandexWeatherRequestCreator Build()
    {
        ConfigureDefault();
        Validate();
        return new YandexWeatherRequestCreator(CreateClient());
    }

    private void ConfigureDefault()
    {
        if (_options.ClientFactory is null && _options.Client is null)
            _options.Client = new HttpClient();
    }

    private IYandexWeatherClient CreateClient()
    {
        return new YandexWeatherClient(_options.ClientFactory, _options.Client, _options.Logger, _options.ApiKey!);
    }

    private void Validate()
    {
        if (string.IsNullOrEmpty(_options.ApiKey))
            throw new ValidationException();

        if (_options.ClientFactory is not null && _options.Client is not null)
            throw new ValidationException();
    }
}
