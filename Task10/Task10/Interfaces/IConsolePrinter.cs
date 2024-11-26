using Task10.Models;
using Task = Task10.Models.Task;

namespace Task10.Interfaces;

public interface IConsolePrinter
{
    void PrintTasks(List<Task> tasks);

    void PrintMessage(string message);
}