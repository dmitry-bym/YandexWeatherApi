namespace YandexWeatherApi.Helpers;

internal static class DictionaryExtensions
{
    internal static void AddIfValueNotNull(this IDictionary<string, string> dictionary, string key, string? value)
    {
        if(value is not null)
            dictionary.Add(key, value);
    }
}
