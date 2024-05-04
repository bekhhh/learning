while (true)
{
    try
    {
        var arraysCount = int.Parse(Console.ReadLine());
        var numbers = new List<int>();
        for (int i = 0; i < arraysCount; i++)
        {
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Введена пустая строка");
                continue;
            }
            var words = input.Split(',')
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(int.Parse)
                .ToArray();
            if (i % 2 == 0)
            {
                numbers.AddRange(words);
            }
            else
            {
                numbers.AddRange(words.Reverse());
            }
        }
        Console.WriteLine(string.Join(", ", numbers));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}