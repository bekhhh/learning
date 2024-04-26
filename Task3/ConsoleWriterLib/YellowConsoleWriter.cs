namespace Task3;

public class YellowConsoleWriter : IConsoleWriter
{
    public void Write(string text)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"info: {text}");
        Console.ResetColor();
    }
}