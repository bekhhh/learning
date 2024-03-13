using System.Text.RegularExpressions;
using System.Threading.Channels;

Console.WriteLine("Введите числа через запятую");
while (true)
{
    var input = Console.ReadLine();
    if (!Regex.IsMatch(input, @"^-?\d+(,\d+)*$")) //задаю шаблон 
    {
        Console.WriteLine("Ошибка: ввод не соответствует формату.");
        continue;
    }
    else
    {
        var numbers = input
            .Split(',')  //тут разбил
            .Select(x => Convert.ToInt32(x))  //сконвертировал
            .ToArray();  // перевел в массив(toArray)
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = 0; j < numbers.Length - i - 1; j++) //сортировка пузырьком
            {
                if (numbers[j] > numbers[j + 1])
                {
                    int temp = numbers[j];
                    numbers[j] = numbers[j + 1];
                    numbers[j + 1] = temp;
                }
            }
        }
        Console.WriteLine("Отсортированные числа:");
        Console.WriteLine(string.Join(", ", numbers)); //собрал И ВЫВЕЛ НА КОНСОЛЬ
    }
}