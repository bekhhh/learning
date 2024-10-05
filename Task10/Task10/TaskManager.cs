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
    private readonly IConsolePrinter _consolePrinter;
    private readonly StorageData _storageData;

    public TaskManager(ITaskRepository tasksRepository, IConsolePrinter consolePrinter, StorageData storageData)
    {
        _tasksRepository = tasksRepository;
        _consolePrinter = consolePrinter;
        _storageData = storageData;
    }

    public void AddTask(TaskRequest addTaskRequest)
    {
        _tasksRepository.LoadTasks();
        var newTask = new Task(_storageData.LastIndexId++, addTaskRequest.Name, addTaskRequest.Description, addTaskRequest.DateTime, addTaskRequest.Priority);
        _storageData.Tasks.Add(newTask);
        _tasksRepository.SaveTasks(_storageData.Tasks, _storageData.LastIndexId); 
        _consolePrinter.PrintTasks(_storageData.Tasks); 
        _consolePrinter.PrintMessage($"Задача {newTask.Name} добавлена.");
    }
    
    public void DeleteTask(TaskRequest deleteTaskRequest)
    {
        var taskToDelete = _storageData.Tasks.FirstOrDefault(t => t.Id == deleteTaskRequest.Id);
        if (taskToDelete != null)
        {
            _storageData.Tasks.Remove(taskToDelete);
            _tasksRepository.SaveTasks(_storageData.Tasks, _storageData.LastIndexId);
            _consolePrinter.PrintTasks(_storageData.Tasks); 
            _consolePrinter.PrintMessage($"Задача под номером {taskToDelete.Id} удалена.");
        }
        else
        {
            _consolePrinter.PrintMessage($"Задача с ID {deleteTaskRequest.Id} не найдена.");
        }
    }
    
    public void UpdateTask(TaskRequest updateTaskRequest)
    {
        var taskToUpdate = _storageData.Tasks.FirstOrDefault(t => t.Id == updateTaskRequest.Id);
        if (taskToUpdate != null)
        {
            _storageData.Tasks.Remove(taskToUpdate);
            _tasksRepository.LoadTasks();
            var updatedTask = new Task(updateTaskRequest.Id, updateTaskRequest.Name,updateTaskRequest.Description, updateTaskRequest.DateTime, updateTaskRequest.Priority);
            _storageData.Tasks.Add(updatedTask);
            _tasksRepository.SaveTasks(_storageData.Tasks, _storageData.LastIndexId);
            _consolePrinter.PrintTasks(_storageData.Tasks);
            _consolePrinter.PrintMessage($"Задача {taskToUpdate.Name} обновлена.");
        }
        else
        {
            _consolePrinter.PrintMessage($"Задача с ID {updateTaskRequest.Id} не найдена.");
        }
    }

    public void ExitApplication()
    {
        _consolePrinter.PrintMessage("Выход из программы.");
    }

    public void HelpMessage()
    {
        _consolePrinter.PrintMessage(InstructionConstants.StartInstruction);
    }

    public void SortTasks(SortRequest sortRequest)
    {
        var sortedTasks = sortRequest.Field.ToLower() switch
        {
            "name" => sortRequest.Ascending
                ? _storageData.Tasks.OrderBy(t => t.Name).ToList()
                : _storageData.Tasks.OrderByDescending(t => t.Name).ToList(),
            "datetime" => sortRequest.Ascending
                ? _storageData.Tasks.OrderBy(t => t.DateTime).ToList()
                : _storageData.Tasks.OrderByDescending(t => t.DateTime).ToList(),
            "priority" => sortRequest.Ascending
                ? _storageData.Tasks.OrderBy(t => t.Priority).ToList()
                : _storageData.Tasks.OrderByDescending(t => t.Priority).ToList(),
            "id" => sortRequest.Ascending
                ? _storageData.Tasks.OrderBy(t => t.Id).ToList()
                : _storageData.Tasks.OrderByDescending(t => t.Id).ToList(),
            _ => throw new InvalidOperationException($"Поле для сортировки '{sortRequest.Field}' не распознано.")
        };
        
        _consolePrinter.PrintTasks(sortedTasks);
        _consolePrinter.PrintMessage("Задачи отсортированы.");
    }
}