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
        var exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
        _filePath = Path.Combine(exeDirectory, "Tasks.txt");
    }
  
    public void SaveTasks(List<Task> tasks, int lastIndexId)
    {
        var dataToSave = new StorageData()
        {
            Tasks = tasks,
            LastIndexId = lastIndexId
        };

        var jsonFormat = JsonSerializer.Serialize(dataToSave);
        File.WriteAllText(_filePath, jsonFormat);
    }

    public void LoadTasks()
    {
        if (!File.Exists(_filePath))
        {
            _consolePrinter.PrintMessage("Файл не найден");
        }
        File.ReadAllText(_filePath);
    }

    public void PrintTasks()
    {
        _consolePrinter.PrintMessage(File.ReadAllText(_filePath));
    }
}
