namespace Task3
{
    public class RedMode : IConsoleWriter
    {
        public string Prefix { get; set; } = "error: ";
        public ConsoleColor Color { get; set; } = ConsoleColor.Red;

        public void Write(string text) 
        {
            Console.WriteLine($"{Prefix}{text}");
        }
    }
}