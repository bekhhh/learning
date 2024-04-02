using Task5.Figures;

Console.WriteLine("Введите описания фигур через запятую: ");
while (true)
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
            .ToArray(); ;
        if (words[0] == "круг")
        {
            if (words.Length != 2)
            {
                Console.WriteLine("Длина ввода не должна быть равна двум");
                continue;
            }
            var circle = new Circle();
            circle.Radius = circle.DoubleParse(words[1]);
            circle.PrintArea();
        }
        else if (words[0] == "треугольник")
        {
            var triangle = new Triangle();
            triangle.Side = triangle.DoubleParse(words[1]);
            triangle.Height = triangle.DoubleParse(words[2]);
            triangle.PrintArea();
        }
        else if (words[0] == "прямоугольник")
        {
            var rectangle = new Rectangle();
            rectangle.SideA = rectangle.DoubleParse(words[1]);
            rectangle.SideB = rectangle.DoubleParse(words[2]);
            rectangle.PrintArea();
        }
        else
        {
            Console.WriteLine("Неверный формат строки.");
            continue;
        }
    }
}