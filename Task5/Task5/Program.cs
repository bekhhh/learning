using Task5;

Console.WriteLine("Введите описания фигур через запятую: ");

while (true)
{
    var input = Console.ReadLine();
    var figure = input.Split(',');
    foreach (var word in figure)
    {
        var index = word.Split(' ');
        if (index[0] == "круг")
        {
            var circle = new Circle { Radius = double.Parse(index[1]) };
            circle.GetArea();
            circle.PrintArea();
        }
        else if (index[0] == "треугольник")
        {
            var triangle = new Triangle { SideA = double.Parse(index[1]), SideB = double.Parse(index[2]) };
            triangle.GetArea();
            triangle.PrintArea();
        }
        else if (index[0] == "прямоугольник")
        {
            var rectangle = new Rectangle { SideA = double.Parse(index[1]), SideB = double.Parse(index[2]) };
            rectangle.GetArea();
            rectangle.PrintArea();
        }
        else
        {
            Console.WriteLine("В наличии только круг,прямоугольник и треугольник");
        }
    }
}
