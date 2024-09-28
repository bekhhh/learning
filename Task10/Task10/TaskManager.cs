using Task10.CommandParsing;
using Task10.FileManager;
using Task10.Interfaces;
using Task10.UserInteraction;
using Task = Task10.Models.Task;

namespace Task10;

public class TaskManager : ITaskManager
{
    public List<Task> Tasks { get; } = new List<Task>();
    private readonly TasksRepository _tasksRepository;
    private readonly ConsolePrinter _consolePrinter;
    private readonly Task _task;

    public TaskManager(TasksRepository tasksRepository, ConsolePrinter consolePrinter, Task task)
    {
        _tasksRepository = tasksRepository;
        _consolePrinter = consolePrinter;
        _task = task;
    }

    public void AddTask(Task result)
    {
        Tasks.Add(result);
        _tasksRepository.SaveTasks(Tasks);
        _consolePrinter.PrintTasks(Tasks);
        _consolePrinter.PrintMessage($"Задача {_task.Name} добавлена.");
    }
    
    public void DeleteTask(Task result)
    {
        Tasks.Remove(result);
        _tasksRepository.SaveTasks(Tasks);
        _consolePrinter.PrintTasks(Tasks);
        _consolePrinter.PrintMessage($"Задача под номером {_task.Id} удалена.");
    }
    
    public void UpdateTask(Task result)
    {
        Tasks.Remove(result); 
        Tasks.Add(result);
        _tasksRepository.SaveTasks(Tasks);
        _consolePrinter.PrintTasks(Tasks);
        _consolePrinter.PrintMessage($"Задача {_task.Name} обновлена.");
    }

    public void ExitApplication()
    {
        _consolePrinter.PrintMessage("Выход из программы.");
    }

    public void HelpMessage()
    {
        _consolePrinter.PrintMessage(InstructionConstants.StartInstruction);
    }

    public void SortTasks()
    {
        _consolePrinter.PrintTasks(Tasks);
        _consolePrinter.PrintMessage("Задачи отсортированы.");
    }
}