namespace YandexWeatherApi.Exceptions;

public class YandexWeatherApiValidationException : YandexWeatherApiException
{
    private readonly string _objectName;
    
    private readonly object? _value;

    internal YandexWeatherApiValidationException(string message, string objectName, object? value = default) : base(message)
    {
        _objectName = objectName;
        _value = value;
    }

    public override string Message
    {
        get
        {
            var s = base.Message;
            if (!string.IsNullOrEmpty(_objectName))
            {
                s += $" Name: {_objectName}, value: {_value ?? "<null>"}";
            }
            return s;
        }
    }
}