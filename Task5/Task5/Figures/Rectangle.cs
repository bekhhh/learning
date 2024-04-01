using System.Globalization;
using Task5.InputParse;
using Task5.Shapes;

namespace Task5.Figures
{
    public class Rectangle : Shape,IDoubleTreangleRectangle
    {
        public double SideA { get; set; }
        public double SideB { get; set; }

        public (double, double) DoubleTreangleRectangleParse(string value1, string value2)
        {
            if (!double.TryParse(value1, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var sideA) ||
               (!double.TryParse(value2, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var sideB)))
            {
                throw new FormatException("Неверный формат строки.");
            }
            else if (sideA <= 0 || sideB <= 0)
            {
                throw new ArgumentException("Стороны не должны быть меньше или равны к нулю.");
            }
            return (sideA, sideB);
        }
        public override double CalculateArea()
        {
            return Math.Round(SideA * SideB, 2);          
        }   
    }
}