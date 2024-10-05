using Task = Task10.Models.Task;

namespace Task10.Interfaces;

public interface ITaskRepository
{
    void SaveTasks(List<Task> tasks, int nextTaskId);
    void LoadTasks();
    void PrintTasks();
}