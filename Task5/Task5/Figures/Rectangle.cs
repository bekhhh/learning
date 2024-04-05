using System.Globalization;
using Task5.Shapes;

namespace Task5.Figures
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