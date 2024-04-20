namespace Task3
{
    public interface IConsoleWriter
    {
        public string Prefix { get; set; }
        public ConsoleColor Color { get; set; }

        public void Write(string text) 
        {
            Color = ConsoleColor.Yellow;
            Prefix = "info: ";
            Console.WriteLine($"{Prefix}{text}");
        }     
    }
}