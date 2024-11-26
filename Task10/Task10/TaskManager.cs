using Task10.CommandParsing;
using Task10.FileManager;
using Task10.Interfaces;
using Task10.Models;
using Task10.Requests;
using Task10.UserInteraction;
using Task = Task10.Models.Task;

namespace Task10;

public class TaskManager : ITaskManager
{
    private readonly ITaskRepository _tasksRepository;

    public TaskManager(ITaskRepository tasksRepository)
    {
        _tasksRepository = tasksRepository;
    }

    public StorageData AddTask(TaskRequest addTaskRequest)
    {
        var storageData = _tasksRepository.LoadTasks();
        var newTask = new Task(++storageData.LastIndexId, addTaskRequest.Name, addTaskRequest.Description, addTaskRequest.DateTime, addTaskRequest.Priority);
        storageData.Tasks.Add(newTask);
        _tasksRepository.SaveTasks(storageData); 
        
        return storageData;
    }

    public StorageData DeleteTask(TaskRequest deleteTaskRequest)
    {
        var storageData = _tasksRepository.LoadTasks();
        var taskToDelete = storageData.Tasks.FirstOrDefault(t => t.Id == deleteTaskRequest.Id);
        if (taskToDelete != null)
        {
            storageData.Tasks.Remove(taskToDelete);
            _tasksRepository.SaveTasks(storageData);
        }
        return storageData;
    }

    public StorageData UpdateTask(TaskRequest updateTaskRequest)
    {
        var storageData = _tasksRepository.LoadTasks();
        var taskToUpdate = storageData.Tasks.FirstOrDefault(t => t.Id == updateTaskRequest.Id);
        if (taskToUpdate != null)
        {
            var updatedTask = taskToUpdate with
            {
                Name = updateTaskRequest.Name,
                Description = updateTaskRequest.Description,
                DateTime = updateTaskRequest.DateTime,
                Priority = updateTaskRequest.Priority
            };
            
            var index = storageData.Tasks.IndexOf(taskToUpdate);
            storageData.Tasks[index] = updatedTask;

            _tasksRepository.SaveTasks(storageData);
        }
        return storageData;
    }

    public StorageData SortTasks(SortRequest sortRequest)
    {
        var storageData = _tasksRepository.LoadTasks();
        var sortedTasks = sortRequest.Field.ToLower() switch
        {
            "name" => sortRequest.Ascending
                ? storageData.Tasks.OrderBy(t => t.Name).ToList()
                : storageData.Tasks.OrderByDescending(t => t.Name).ToList(),
            "datetime" => sortRequest.Ascending
                ? storageData.Tasks.OrderBy(t => t.DateTime).ToList()
                : storageData.Tasks.OrderByDescending(t => t.DateTime).ToList(),
            "priority" => sortRequest.Ascending
                ? storageData.Tasks.OrderBy(t => t.Priority).ToList()
                : storageData.Tasks.OrderByDescending(t => t.Priority).ToList(),
            "id" => sortRequest.Ascending
                ? storageData.Tasks.OrderBy(t => t.Id).ToList()
                : storageData.Tasks.OrderByDescending(t => t.Id).ToList(),
            _ => throw new InvalidOperationException($"Поле для сортировки '{sortRequest.Field}' не распознано.")
        };

        storageData.Tasks = sortedTasks;
        return storageData;
    }
}