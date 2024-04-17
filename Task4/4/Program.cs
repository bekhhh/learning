using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var dictionary = new Dictionary<string, List<int>>();
Console.WriteLine("Введите путь к файлу ");
var filePath = Console.ReadLine(); //C:\Projects\forTask.txt => мой путь к файлу
if (!File.Exists(filePath)) // проверяем на наличие файла
{
    Console.WriteLine("Файл не существует");
    return;
}
var lines = File.ReadAllLines(filePath); // читаем файл
var firstLine = lines[0];
var arrayOfSymbols = firstLine.Split(',')
                       .Select(x => x.Trim())
                       .Where(x => !string.IsNullOrEmpty(x))
                       .ToArray(); // тут разделили и убрали лишние пробелы
for (int i = 1; i < lines.Length; i++) // начинаем с первого индекса, тк как 0 индекс нам не нужен(там наши символы)
{
    var currentLine = lines[i];
    foreach (var symbol in arrayOfSymbols)
    {
        int count = currentLine.Count(c => c.ToString() == symbol); // подсчет количества символов в оставшиеся 2 строках 
        if (!dictionary.ContainsKey(symbol))
        {
            dictionary[symbol] = new List<int>(); // если не встречался, то добавляем 
        }
        dictionary[symbol].Add(count); // тут добавляем количество вхождений в строку, если встртечался
    }
}
foreach (var с in dictionary)
{
    Console.WriteLine($"{с.Key}: {string.Join(", ", с.Value)}"); // в таске не обязательно, но я вывел на всякий
}
var newFilePath = @"C:\Projects";
var newFile = "forTask " + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt"; // надюсь правильно понял про суфикс
string fullFilePath = Path.Combine(newFilePath, newFile);
using (StreamWriter writer = new StreamWriter(fullFilePath)) // тут уже идет запись в новый файл
{
    foreach (var v in dictionary)
    {
        writer.WriteLine($"{v.Key}: {string.Join(", ", v.Value)}");
    }
}