namespace Task5
{
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override double Area { get; set; }

        public override double GetArea()
        {
            Area = Math.Round(Math.PI * Math.Pow(Radius, 2), 2);
            return Area;
        }
        public override void PrintArea()
        {
            Console.WriteLine($"Площадь круга: {Area}");
        }
    }
}
