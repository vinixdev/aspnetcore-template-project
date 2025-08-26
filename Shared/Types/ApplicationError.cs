namespace Shared.Types;

public class ApplicationError
{
    public string Key { get; }
    public string Message { get; }

    public static ApplicationError Of(string key, string message)
    {
        return new ApplicationError(key, message);
    }

    private ApplicationError(string key, string message)
    {
        Key = key;
        Message = message;
    }
}