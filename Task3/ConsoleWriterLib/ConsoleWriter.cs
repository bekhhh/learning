namespace _3
{
    public abstract class ConsoleWriter
    {
        public abstract string Prefix { get; set; }       
        public abstract void Write(string value);      
    }
}