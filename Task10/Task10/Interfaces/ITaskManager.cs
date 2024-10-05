using Task10.CommandParsing;
using Task10.Requests;
using Task = Task10.Models.Task;

namespace Task10.Interfaces;

public interface ITaskManager
{
    void AddTask(TaskRequest addTaskRequest);
    void DeleteTask(TaskRequest deleteTaskRequest);
    void UpdateTask(TaskRequest updateTaskRequest);
    void ExitApplication();
    void SortTasks(SortRequest sortRequest);

    void HelpMessage();
}