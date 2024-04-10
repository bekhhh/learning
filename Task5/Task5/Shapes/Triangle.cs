using System.Globalization;

namespace Task5.Shapes
{
    public class Triangle : Shape
    {
        public double Side { get; set; }
        public double Height { get; set; }

        public override double CalculateArea()
        {
            return Math.Round(Side * Height / 2, 2);
        }
    }
}