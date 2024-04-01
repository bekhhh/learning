using System.Drawing;
using System.Globalization;
using Task5.InputParse;
using Task5.Shapes;

namespace Task5.Figures
{
    public class Triangle : Shape, IDoubleTreangleRectangle
    {
        public double Side { get; set; }
        public double Height { get; set; }

        public (double, double) DoubleTreangleRectangleParse(string value1, string value2)
        {
            if (!double.TryParse(value1, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var side) ||
               (!double.TryParse(value2, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var height)))
            {
                throw new FormatException("Неверный формат строки.");
            }
            else if (side <= 0 || height <= 0)
            {
                throw new ArgumentException("Высота или сторона не должны быть меньше или равны к нулю.");
            }
            return (side, height);
        }
        public override double CalculateArea()
        {
            return Math.Round(Side * Height / 2, 2);
        }
    }
}