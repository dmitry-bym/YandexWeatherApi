namespace YandexWeatherApi;

/// <summary>
/// Create new instance of <c>WeatherLocality</c>.
/// </summary>
/// <param name="Latitude">
/// The latitude in degrees.
/// </param>
/// <param name="Longitude">
/// The longitude in degrees.
/// </param>
public record WeatherLocality(double Latitude, double Longitude);
