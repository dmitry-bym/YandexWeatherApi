namespace YandexWeatherApi.Helpers;

public static class DictionaryExtensions
{
    public static void AddIfValueNotNull(this IDictionary<string, string> dictionary, string key, object? value)
    {
        if(value is not null)
            dictionary.Add(key, value.ToString()!);
    }
}
