using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Task10.FileManager;

public class FileWriter
{
    private TaskManager _taskManager;
    private string filePath = @"C:\Projects\learning\Task10\Task10\bin\Debug\net8.0\Tasks.txt";

    public FileWriter(TaskManager taskManager)
    {
        _taskManager = taskManager;
    }
    
    public void WriteTasksToFile()
    {
        var jsonFormat = JsonConvert.SerializeObject(_taskManager.Tasks, Formatting.Indented);
        File.WriteAllText(filePath, jsonFormat);
    }
}