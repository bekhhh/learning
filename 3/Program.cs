var color = ConsoleColor.Yellow;
while (true)
{
    var input = Console.ReadLine();
    if (input == "switch")
    {
        if (color == ConsoleColor.Yellow)
        {
            color = ConsoleColor.Red;
            Console.ResetColor();
        }
        else
        {

            color = ConsoleColor.Yellow;
        }
        Console.WriteLine("Цвет изменен");
    }
    else
    {
        Console.ForegroundColor = color;
        Console.WriteLine(input);
        Console.ForegroundColor = ConsoleColor.White;
    }
}