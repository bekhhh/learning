using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Task10.FileManager;

public class FileWriter
{
    private TaskManager _taskManager;
    private string filePath;

    public FileWriter(TaskManager taskManager)
    {
        _taskManager = taskManager;
        string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
        filePath = Path.Combine(exeDirectory, "Tasks.txt");
    }
    
    public void WriteTasksToFile()
    {
        var jsonFormat = JsonConvert.SerializeObject(_taskManager.Tasks, Formatting.Indented);
        File.WriteAllText(filePath, jsonFormat);
    }
}