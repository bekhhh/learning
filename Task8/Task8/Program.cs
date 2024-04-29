using System;
using System.Xml.Linq;

 static int ReverseNumber(int number)
{
    int reversedNumber = 0;
    while (number > 0)
    {
        reversedNumber = reversedNumber * 10 + number % 10;
        number /= 10;
    }
    return reversedNumber;
}
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

        for (int i = 0; i < words.Length; i++)
        {
            if (!int.TryParse(words[i], out int number))
            {
                throw new FormatException("Неверный формат строки.");
            }
            else if (number <= 0)
            {
                throw new ArgumentException("Числа не должны быть меньше или равны к нулю.");
            }

            if (i % 2 == 0)
            {
                var reversedNumber = ReverseNumber(number);
                Console.Write(reversedNumber + " ");
            }
            else
            {
                Console.Write(number + " ");
            }
        }
        Console.WriteLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        continue;
    }
}
