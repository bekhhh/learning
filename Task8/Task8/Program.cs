while (true)
{
    try
    {
        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Введена пустая строка");
        }
        var numbersArray = input.Split(',')
            .Select(x => x.Trim())
            .Where(x => !string.IsNullOrEmpty(x))
            .ToArray();
        foreach (var numbers in numbersArray)
        {
            if (!int.TryParse(numbers, out var number))
            {
                throw new FormatException("Неверный формат строки");
            }
            else if (number <= 0)
            {
                throw new ArgumentException("Числа не должны быть меньше или равны к нулю.");
            }           
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}