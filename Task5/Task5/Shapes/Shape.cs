using System.Globalization;

namespace Task5.Shapes
{
    public abstract class Shape
    {               
        public double ParseToDouble(string value)
        {
            if (!double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var element))
            {
                throw new FormatException("Неверный формат строки.");                
            }
            else if (element <= 0)
            {
                throw new ArgumentException("Элемент фигуры не должен быть меньше или равен нулю.");
            }
            return element;
        }
        public abstract double CalculateArea();
        public void PrintArea()
        {
            Console.Write($"{CalculateArea()} ");
            Console.WriteLine();
        }       
    }
}