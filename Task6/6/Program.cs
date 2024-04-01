using System.Diagnostics.Tracing;

Console.WriteLine("Введите текст: ");
while (true)
{
    var input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input))
    {
        Console.Write("Ошибка: Введите текст ");
        continue;
    }
    var words = input.Split(' ').
        Select(x => x.Trim()).
        Where(x => !string.IsNullOrEmpty(x)).
        ToArray();
    var dictionary = new Dictionary<string, List<int>>();
    for (int i = 0; i < words.Length; i++)
    {
        var word = words[i];
        if (!dictionary.ContainsKey(word))
        {
            dictionary[word] = new List<int>();
        }
        dictionary[word].Add(i + 1);
    }
    foreach (var (item, positions) in dictionary)
    {
        Console.WriteLine($"Слово:\"{item}\", количество: {positions.Count}, позиция: {string.Join(" ", positions)} ");
    }
}