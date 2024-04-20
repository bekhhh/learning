using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Xml.Linq;

namespace Task3
{   
    public class ConsoleHandler
    {
        private IConsoleWriter _writer;       
        public void StartHandlingInput()
        {
            _writer.Write();
            while (true)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Введена пустая строка");
                }
                if (input == "switch")
                {                                     
                    Console.WriteLine("Цвет изменен");
                    if () 
                    { 
                    
                    }
                }
                Console.ForegroundColor = Color;
                Console.WriteLine($"{Prefix}{input}");
                Console.ResetColor();
            }
        }       
    }
}