using System.Globalization;
using Task5;
using Task5.Figures;

Console.WriteLine("Введите описания фигур через запятую: ");
while (true)
{
    try
    {
        var input = Console.ReadLine();
        var figures = input.Split(',');
        foreach (var figure in figures)
        {
            var words = figure.Split(' ')
                .Select(x => x.Trim())
                  .Where(x => !string.IsNullOrEmpty(x))
                  .ToArray(); ;
            if (words[0] == "круг")
            {
                var circle = new Circle();
                circle.Radius = circle.DoubleCircleParse(words[1]);
                circle.PrintArea();
            }
            else if (words[0] == "треугольник")
            {
                var triangle = new Triangle();
                var (side, height) = triangle.DoubleTreangleRectangleParse(words[1], words[2]);
                triangle.Side = side;
                triangle.Height = height;
                triangle.PrintArea();
            }
            else if (words[0] == "прямоугольник")
            {
                var rectangle = new Rectangle();
                var (sideA, sideB) = rectangle.DoubleTreangleRectangleParse(words[1], words[2]);
                rectangle.SideA = sideA;
                rectangle.SideB = sideB;
                rectangle.PrintArea();
            }
            else
            {
                throw new FormatException("Неверный формат строки.");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        continue;
    }
}