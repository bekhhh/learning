using System.Text.Json;
using Task10.Interfaces;
using Task = Task10.Models.Task;

namespace Task10.UserInteraction;

public class ConsolePrinter : IConsolePrinter
{
    private readonly string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;

    public ConsolePrinter()
    {
        Path.Combine(exeDirectory, "Tasks.txt");
    }

    public void PrintTasks(List<Task> tasks)
    {
        Console.Clear();
        foreach (var task in tasks)
        {
            Console.WriteLine(JsonSerializer.Serialize(task));
        }
    }

    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }
    
}