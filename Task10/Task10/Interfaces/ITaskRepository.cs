using Task = Task10.Models.Task;

namespace Task10.Interfaces;

public interface ITaskRepository
{
    void SaveTasks(List<Task> tasks);
    void LoadTasks();
    void PrintTasks();
}