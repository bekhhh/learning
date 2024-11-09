using System.Text.Json;
using Task10.Interfaces;
using Task10.Models;
using Task = Task10.Models.Task;

namespace Task10.UserInteraction;

public class ConsolePrinter : IConsolePrinter
{
    public void PrintTasks(List<Task> tasks)
    {
        Console.Clear();
        foreach (var task in tasks)
        {
            Console.WriteLine(JsonSerializer.Serialize(task, new JsonSerializerOptions { WriteIndented = true }));
        }
    }

    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }
}