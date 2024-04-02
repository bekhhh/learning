using System.Globalization;
using Task5.Shapes;

namespace Task5.Figures
{
    public class Rectangle : Shape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }

        public override double DoubleParse(string value)
        {
            if (!double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var side))
            {
                throw new FormatException("Неверный формат строки.");
            }
            else if (side <= 0)
            {
                throw new ArgumentException("Сторона не должна быть меньше или равна к нулю.");
            }
            return side;
        }
        public override double CalculateArea()
        {
            return Math.Round(SideA * SideB, 2);          
        }   
    }
}