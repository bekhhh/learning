using System;
using System.IO;
using Newtonsoft.Json;

namespace Task10.FileManager;

public class ConsolePrinter
{
    private string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
    private string filePath;

    public ConsolePrinter()
    {
        filePath = Path.Combine(exeDirectory, "Tasks.txt");
    }

    public void PrintTasks(List<Task> tasks)
    {
        Console.Clear();
        foreach (var task in tasks)
        {
            Console.WriteLine(JsonConvert.SerializeObject(task, Formatting.Indented));
        }
    }
}