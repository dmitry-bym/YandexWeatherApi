using YandexWeatherApi.Exceptions;

namespace YandexWeatherApi;

internal class YandexWeatherServiceBuilder : IYandexWeatherServiceBuilder
{
    private readonly YandexWeatherOptions _options = new();

    internal YandexWeatherServiceBuilder()
    {
    }

    public IYandexWeatherServiceBuilder Configure(Action<YandexWeatherOptions> configureOptions)
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
        if (string.IsNullOrWhiteSpace(_options.ApiKey))
            throw new YandexWeatherApiValidationException("Can not be null or empty", nameof(_options.ApiKey), "***");

        if (_options.ClientFactory is not null && _options.Client is not null)
            throw new YandexWeatherApiConflictException($"Unable to use {nameof(_options.ClientFactory)} and {nameof(_options.Client)} together");
    }
}
