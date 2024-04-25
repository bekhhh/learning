using Task3;

public class RedRealization : IConsoleWriter
{
    public string Write(string text)
    {
        return $"error: {text}";
    }
}