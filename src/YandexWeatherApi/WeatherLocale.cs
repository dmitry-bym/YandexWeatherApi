namespace YandexWeatherApi;

/// <summary>
/// <c>WeatherLocale</c> is alias for locales
/// </summary>
public record WeatherLocale
{
    public string Locale { get; }
    
    private WeatherLocale(string locale)
    {
        Locale = locale;
    }

    /// <summary>
    /// Russian for the Russia locale.
    /// </summary>
    public static readonly WeatherLocale ru_RU = new("ru_RU");
    
    /// <summary>
    /// Russian for the Ukraine locale.
    /// </summary>
    public static readonly WeatherLocale ru_UA = new("ru_UA");
    
    /// <summary>
    /// Ukrainian for the Ukraine locale.
    /// </summary>
    public static readonly WeatherLocale uk_UA = new("uk_UA");
    
    /// <summary>
    /// Belarusian for the Belarus locale.
    /// </summary>
    public static readonly WeatherLocale be_BY = new("be_BY");
    
    /// <summary>
    /// Kazakh for the Kazakhstan locale.
    /// </summary>
    public static readonly WeatherLocale kk_KZ = new("kk_KZ");
    
    /// <summary>
    /// Turkish for the Turkey locale.
    /// </summary>
    public static readonly WeatherLocale tr_TR = new("tr_TR");
    
    /// <summary>
    /// International English.
    /// </summary>
    public static readonly WeatherLocale en_US = new("en_US");
}