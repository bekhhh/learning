using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Xml.Linq;

namespace Task3
{
    public class ConsoleHandler
    {
        public SwitchMode Mode { get; set; }
        private string Prefix { get; set; } = "info: ";
        public ConsoleColor Color { get; set; } = ConsoleColor.Yellow;

        public void StartHandlingInput()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Введена пустая строка");
                }
                if (input == "switch")
                {                 
                    ChangeMode();
                    Console.WriteLine("Цвет изменен");
                }
                Console.ForegroundColor = Color;
                Console.WriteLine($"{Prefix}{input}");
                Console.ResetColor();
            }
        }
        private void ChangeMode()
        {
            Mode = Mode == SwitchMode.YellowMode ? SwitchMode.RedMode : SwitchMode.YellowMode;
            Color = Mode == SwitchMode.YellowMode ? ConsoleColor.Yellow : ConsoleColor.Red;
            Prefix = Mode == SwitchMode.YellowMode ? "info: " : "error: ";
        }
    }
}