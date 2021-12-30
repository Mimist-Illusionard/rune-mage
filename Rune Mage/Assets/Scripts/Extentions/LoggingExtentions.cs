
public static class LoggingExtentions
{
    public static void Log(this string @string)
    {
        UnityEngine.Debug.Log(@string);
    }

    public static void LogWarning(this string @string)
    {
        UnityEngine.Debug.LogWarning(@string);
    }

    public static void LogError(this string @string)
    {
        UnityEngine.Debug.LogError(@string);
    }
}
