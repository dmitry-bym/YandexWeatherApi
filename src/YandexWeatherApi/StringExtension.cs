namespace YandexWeatherApi;

public static class StringExtension
{
    public static string StringJoin<T>(this IEnumerable<T> enumerable, char separator)
    {
        return string.Join(separator, enumerable);
    }
}