using System.Globalization;
using Example_1;
using Example_1.Tree;
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

    var result = ParseTree(input.ToCharArray());

    if (result.IsError)
    {
        Console.WriteLine("Выражение написано не корректно");
        Console.WriteLine("Введите выражение, используя символы * / + - и целые или дробные числа (отрицательные тоже)");
        continue;
    }

    var termResult = result.Tree?.GetResult();
    Console.WriteLine($"Результат: {termResult}");
    //var terms = input.Split('+').Select(x => x.Trim());

    //Пример 1
    // var result = new List<string>();
    // foreach (var item in terms)
    // {
    //     result.AddRange(item.Split('-').Select(x => x.Trim()));
    // }
    // terms = result;

    //Пример 2 аналогичный
    // terms = terms
    //     .SelectMany(x => x
    //         .Split('-')
    //         .Select(y => y.Trim()));


}

ParsingResult ParseTree(char[] value)
{
    var left = string.Empty;
    foreach (var symbol in value)
    {
        if (symbol == '+' || symbol == '-')
        {
            var currentOperation = symbol == '+'
                ? Operation.Plus
                : Operation.Minus;

            var leftResult = ParseLeftTree(left.ToCharArray());
            if (leftResult.IsError)
            {
                return new ParsingResult
                {
                    IsError = true,
                    ErrorMessage = leftResult.ErrorMessage,
                };
            }
            
            var rightResult = ParseTree(value.Skip(left.Length + 1).ToArray());
            if (rightResult.IsError)
            {
                return new ParsingResult
                {
                    IsError = true,
                    ErrorMessage = rightResult.ErrorMessage,
                };
            }
                    
            return new ParsingResult
            {
                Tree = new Tree
                {
                    Left = leftResult.Tree,
                    Right = rightResult.Tree,
                    Operation = currentOperation,
                }
            };

        }
        
        left += symbol;
    }

    return ParseLeftTree(left.ToCharArray());
}

ParsingResult ParseLeftTree(char[] value)
{
    var left = string.Empty;
    foreach (var symbol in value)
    {
        if (symbol == '*' || symbol == '/')
        {
            // if (symbol == '*')
            // {
            //     currentOperation = Operation.Multiply;
            // }
            // else
            // {
            //     currentOperation = Operation.Divide;
            // }
            //тоже самое
            var currentOperation = symbol == '*'
                ? Operation.Multiply
                : Operation.Divide;

            if (!double.TryParse(left.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out var dValue))
            {
                return new ParsingResult
                {
                    IsError = true,
                    ErrorMessage = "Неверный формат строки."
                };
            }
            
            var leftTree = new Tree
            {
                Number = dValue,
                Operation = Operation.None,
            };
            var rightResult = ParseLeftTree(value.Skip(left.Length + 1).ToArray());
            if (rightResult.IsError)
            {
                return new ParsingResult
                {
                    IsError = true,
                    ErrorMessage = rightResult.ErrorMessage,
                };
            }
                    
            return new ParsingResult
            {
                Tree = new Tree
                {
                    Left = leftTree,
                    Right = rightResult.Tree,
                    Operation = currentOperation,
                }
            };

        }
        
        left += symbol;
    }

    if (double.TryParse(left.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out var dValue2))
    {
        return new ParsingResult
        {
            Tree = new Tree
            {
                Number = dValue2,
                Operation = Operation.None,
            }
        };
    }
    
    return new ParsingResult
    {
        IsError = true,
        ErrorMessage = "Неверный формат строки."
    };
}