using Task10.CommandParsing;
using Task10.Models;
using Task10.Requests;
using Task = Task10.Models.Task;

namespace Task10.Interfaces;

public interface ITaskManager
{
    StorageData AddTask(TaskRequest addTaskRequest);
    StorageData DeleteTask(TaskRequest deleteTaskRequest);
    StorageData UpdateTask(TaskRequest updateTaskRequest);
    StorageData SortTasks(SortRequest sortRequest);
}