using Task3;

public class YellowRealization : IConsoleWriter
{
    public string Write(string text)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        return $"info: {text}";
    }
}