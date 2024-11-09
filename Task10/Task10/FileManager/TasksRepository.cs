using System.Text.Json;
using System.Threading.Channels;
using Task10.Interfaces;
using Task10.Models;
using Task = Task10.Models.Task;

namespace Task10.FileManager;

public class TasksRepository : ITaskRepository
{
    private readonly string _filePath;
    private readonly IConsolePrinter _consolePrinter;

    public TasksRepository(IConsolePrinter consolePrinter)
    {
        _consolePrinter = consolePrinter;
        _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tasks.txt");
    }
  
    public void SaveTasks(StorageData storageData)
    {
        var jsonFormat = JsonSerializer.Serialize(storageData);
        File.WriteAllText(_filePath, jsonFormat);
    }

    public StorageData LoadTasks()
    {
        if (!File.Exists(_filePath))
        {
            _consolePrinter.PrintMessage("Файл не найден");
        }
        var jsonData = File.ReadAllText(_filePath);
        if (string.IsNullOrWhiteSpace(jsonData))
        {
            _consolePrinter.PrintMessage("Пока нет задач");
            return new StorageData();
        }
        var storageData =  JsonSerializer.Deserialize<StorageData>(jsonData);
        return storageData;
    }
}
