using Task5.Shapes;

var shapes = new List<Shape>();
Console.WriteLine("Введите описания фигур через запятую: ");
while (true)
{
    try
    {
        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Нельзя вводить пустую строку");
            continue;
        }
        var figures = input.Split(',');
        foreach (var figure in figures)
        {
            var words = figure.Split(' ')
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrEmpty(x))
                .ToArray();
            if (words[0] == "круг")
            {
                if (words.Length != 2)
                {
                    Console.WriteLine("Длина ввода для круга должна быть равна двум");
                    continue;
                }
                var circle = new Circle();
                circle.Radius = circle.ParseToDouble(words[1]);
                shapes.Add(circle);
            }
            else if (words[0] == "треугольник")
            {
                if (words.Length != 3)
                {
                    Console.WriteLine("Длина ввода для треугольника должна быть равна трем");
                    continue;
                }
                var triangle = new Triangle();
                triangle.Side = triangle.ParseToDouble(words[1]);
                triangle.Height = triangle.ParseToDouble(words[2]);
                shapes.Add(triangle);
            }
            else if (words[0] == "прямоугольник")
            {
                if (words.Length != 3)
                {
                    Console.WriteLine("Длина ввода для прямоугольника должна быть равна трем");
                    continue;
                }
                var rectangle = new Rectangle();
                rectangle.SideA = rectangle.ParseToDouble(words[1]);
                rectangle.SideB = rectangle.ParseToDouble(words[2]);
                shapes.Add(rectangle);
            }
            else
            {
                Console.WriteLine("Неверный формат строки.");
            }
        }
        foreach (var shape in shapes)
        {
            shape.PrintArea();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}