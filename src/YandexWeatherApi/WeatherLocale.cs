namespace YandexWeatherApi;

public class WeatherLocale
{
    public string Locale { get; }
    public string Description { get; }
    private WeatherLocale(string locale, string description)
    {
        Locale = locale;
        Description = description;
    }

    public static readonly WeatherLocale ru_RU = new WeatherLocale("ru_RU", "Russian for the Russia locale.");
    
    public static readonly WeatherLocale ru_UA = new WeatherLocale("ru_UA", " Russian for the Ukraine locale.");
    
    public static readonly WeatherLocale uk_UA = new WeatherLocale("uk_UA", " Ukrainian for the Ukraine locale.");
    
    public static readonly WeatherLocale be_BY = new WeatherLocale("be_BY", "Belarusian for the Belarus locale.");
    
    public static readonly WeatherLocale kk_KZ = new WeatherLocale("kk_KZ", "Kazakh for the Kazakhstan locale.");
    
    public static readonly WeatherLocale tr_TR = new WeatherLocale("tr_TR", "Turkish for the Turkey locale.");
    
    public static readonly WeatherLocale en_US = new WeatherLocale("en_US", "International English.");
}