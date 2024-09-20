using System;
using System.IO;
using Newtonsoft.Json;

namespace Task10.FileManager;

public class ConsolePrinter
{
    string filePath = @"C:\Projects\learning\Task10\Task10\bin\Debug\net8.0\Tasks.txt";
    string[] tasks;
    
    public void PrintTasks(List<Task> tasks)
    {
        Console.Clear();
        foreach (var task in tasks)
        {
            Console.WriteLine(JsonConvert.SerializeObject(task, Formatting.Indented));
        }
    }
}