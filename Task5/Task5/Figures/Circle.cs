using System.Globalization;
using Task5.InputParse;
using Task5.Shapes;

namespace Task5.Figures
{
    public class Circle : Shape, IDoubleCircleParse
    {
        public double Radius { get; set; }

        public double DoubleCircleParse(string value)
        {
            if (!double.TryParse(value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var radius))
            {
                throw new FormatException("Неверный формат строки.");
            }
            else if (radius <= 0)
            {
                throw new ArgumentException("Радиус не должен быть меньше или равен нулю.");
            }
            return radius;
        }
        public override double CalculateArea()
        {
            return Math.Round(Math.PI * Math.Pow(Radius, 2), 2);
        }
    }
}