using Task3;

public class ConsoleHandler
{
    IConsoleWriter writer = new YellowRealization();
    public void StartHandlingInput()
    {
        while (true)
        {
            var input = Console.ReadLine();
            if (input == "switch")
            {
                if (writer is YellowRealization)
                {
                    writer = new RedRealization();
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    writer = new YellowRealization();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine("Цвет изменен");
            }
            else
            {
                string mode = writer.Write(input);
                Console.WriteLine(mode);
            }
        }
    }
}