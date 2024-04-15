namespace Task3
{
    public interface IConsoleWriter
    {        
        public string Prefix { get; init; }
        public void Write(string text) 
        {
            Console.WriteLine(text);
        }     
    }
}