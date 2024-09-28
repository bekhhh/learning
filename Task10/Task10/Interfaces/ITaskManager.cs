using Task10.CommandParsing;
using Task = Task10.Models.Task;

namespace Task10.Interfaces;

public interface ITaskManager
{
    void AddTask(Task result);
    void DeleteTask(Task result);
    void UpdateTask(Task result);
    void ExitApplication();
    void SortTasks();

    void HelpMessage();
}