namespace Task5.Shapes
{
    public abstract class Shape
    {
        public abstract double DoubleParse(string value);       
        public abstract double CalculateArea();
        public void PrintArea()
        {
            Console.Write($"{CalculateArea()} ");
        }
    }
}