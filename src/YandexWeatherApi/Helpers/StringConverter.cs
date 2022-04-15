using System.Globalization;

namespace YandexWeatherApi.Helpers;

internal static class StringConverter
{
    internal static string? Convert(bool? value)
    {
        if (!value.HasValue)
            return null;
        
        return value.Value ? "true" : "false";
    }
    
    internal static string? Convert(int? value)
    {
        return value?.ToString(CultureInfo.InvariantCulture);
    }
    
    internal static string? Convert(double? value)
    {
        return value?.ToString(CultureInfo.InvariantCulture);
    }
}
