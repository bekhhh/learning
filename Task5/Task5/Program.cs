using System.Globalization;
using Task5;
using Task5.Figures;

Console.WriteLine("Введите описания фигур через запятую: ");
while (true)
{
    try
    {
        var input = Console.ReadLine();
        var figure = input.Split(',');
        foreach (var word in figure)
        {
            var index = word.Split(' ').
                Select(x => x.Trim()).
                ToArray();
            if (index[0] == "круг")
            {
                var circle = new Circle
                {
                    Radius = double.Parse(index[1], CultureInfo.InvariantCulture)
                };
                circle.PrintArea();
            }
            else if (index[0] == "треугольник")
            {
                var triangle = new Triangle
                {
                    Side = double.Parse(index[1], CultureInfo.InvariantCulture),
                    Height = double.Parse(index[2], CultureInfo.InvariantCulture)
                };
                triangle.PrintArea();
            }
            else if (index[0] == "прямоугольник")
            {
                var rectangle = new Rectangle
                {
                    SideA = double.Parse(index[1], CultureInfo.InvariantCulture),
                    SideB = double.Parse(index[2], CultureInfo.InvariantCulture)
                };
                rectangle.PrintArea();
            }
            else
            {
                Console.WriteLine("В наличии только круг,прямоугольник и треугольник");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        continue;
    }
}