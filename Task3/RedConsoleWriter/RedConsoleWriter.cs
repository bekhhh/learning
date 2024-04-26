using Task3;

public class RedConsoleWriter : IConsoleWriter
{
    public void Write(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"error: {text}");
        Console.ResetColor();
    }
}