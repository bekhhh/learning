using System;
using System.Xml.Linq;

var numbersArray = new List<int>();
while (true)
{
    try
    {
        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Введена пустая строка");
            continue;
        }
        var words = input.Split('.', '?', '!', ' ', ';', ':', ',')
        .Select(x => x.Trim())
        .Where(x => !string.IsNullOrEmpty(x))
        .ToArray();
        foreach (var word in words)
        {
            if (!int.TryParse(word, out int numbers))
            {
                throw new FormatException("Неверный формат строки.");
            }
            else if (numbers <= 0)
            {
                throw new ArgumentException("Числа не должны быть меньше или равны к нулю.");
            }
            numbersArray.Add(numbers);
            for (int i = 0; i < numbers.Count; i++)
            {
                var array1 = words[i];

                if (i % 2 == 0)
                {
                    // четный индекс
                    // обрабатываем массив в обратном порядке
                }
                else
                {
                    // нечетный индекс
                    // обрабатываем массив в прямом порядке
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        continue;
    }
}
