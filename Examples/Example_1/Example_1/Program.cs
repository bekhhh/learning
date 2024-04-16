using Example_1.TreeBuilding;
Console.WriteLine("Введите выражение, используя символы * / + - и целые или дробные числа (отрицательные тоже)");

while (true)

{
    var input = Console.ReadLine();
    if (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("Нельзя вводить пустую строку");
        continue;
    }
    
    input = input.Trim();
    if (input == "end")
    {
        break;
    }

    var parser = new TreeParser();
    var result = parser.ParseTree(input);

    if (result.IsError)
    {
        Console.WriteLine(result.ErrorMessage);
        Console.WriteLine("Введите выражение, используя символы * / + - и целые или дробные числа (отрицательные тоже)");
        continue;
    }

    var termResult = result.Tree.GetResult();
    Console.WriteLine($"Результат: {termResult}");
}