using ConsoleWriterLib;
using RedConsoleWriterLib;

namespace Task3
{
    public class ConsoleHandler
    {
        IConsoleWriter writer = new YellowConsoleWriter();
        public void StartHandlingInput()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "switch")
                {
                    if (writer is YellowConsoleWriter)
                    {
                        writer = new RedConsoleWriter();
                    }
                    else
                    {
                        writer = new YellowConsoleWriter();
                    }
                    Console.WriteLine("Цвет изменен");
                }
                else
                {
                    writer.Write(input);
                }
            }
        }
    }
}