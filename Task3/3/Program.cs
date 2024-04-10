
var color = ConsoleColor.Yellow;
string prefix = "info: ";
while (true)
{
    var input = Console.ReadLine();
    if (input == "switch")
    {
        if (color == ConsoleColor.Yellow)
        {
            color = ConsoleColor.Red;
            prefix = "error: ";
            Console.ResetColor();
        }
        else if (color == ConsoleColor.Red)
        {
            color = ConsoleColor.Yellow;
            prefix = "info: ";
            Console.ResetColor();
        }
        Console.WriteLine("Цвет изменен");
    }
    else
    {
        Console.ForegroundColor = color;
        Console.WriteLine($"{prefix}{input}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}