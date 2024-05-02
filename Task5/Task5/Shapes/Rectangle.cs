using System.Globalization;

namespace Task5.Shapes
{
    public class Rectangle : Shape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }

        public override double CalculateArea()
        {
            return Math.Round(SideA * SideB, 2);
        }
    }
}