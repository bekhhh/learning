using System;
using System.IO;
using System.Linq;

Console.WriteLine("Введите путь к файлу ");
var filePath = Console.ReadLine(); //C:\Projects\forTask.txt => мой путь к файлу
if (!File.Exists(filePath))
{
    Console.WriteLine("Файл не существует");
    return;
}
var lines = File.ReadAllLines(filePath);
var firstLine = lines[0];
var arrayOfSymbols = firstLine.Split(',')
                       .Select(x => x.Trim())
                       .Where(x => !string.IsNullOrEmpty(x))
                       .Select(x => x[0])
                       .ToArray();
var newFilePath = Path.GetDirectoryName(filePath);
var newFile = "forTask " + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt";
string fullFilePath = Path.Combine(newFilePath, newFile);
using (StreamWriter writer = new StreamWriter(fullFilePath)) 
{
    for (int i = 1; i < lines.Length; i++)
    {
        var currentLine = lines[i];
        foreach (char symbol in arrayOfSymbols)
        {
            int count = currentLine.Count(c => c == symbol);
            writer.Write($"{count} ");
        }
        writer.WriteLine();
    }
}