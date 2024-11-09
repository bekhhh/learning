using Task10.Interfaces;
using Task10.Models;

namespace Task10.UserInteraction;

public class InputHandler
{
    private readonly ICommandParser _parser;
    private readonly IConsolePrinter _consolePrinter;
    private readonly ITaskManager _taskManager;
    private readonly ITaskRepository _taskRepository;

    public InputHandler(ICommandParser parser, IConsolePrinter consolePrinter, ITaskManager taskManager, ITaskRepository taskRepository)
    {
        _parser = parser;
        _consolePrinter = consolePrinter;
        _taskManager = taskManager;
        _taskRepository = taskRepository;
    }

    public void HandleInput()
    {
        var loadTask = _taskRepository.LoadTasks();
        _consolePrinter.PrintTasks(loadTask.Tasks);
        _consolePrinter.PrintMessage(InstructionConstants.StartInstruction);
        while (true)
        {
            try
            {
                var input = Console.ReadLine();
                var result = _parser.ParseCommand(input);
                switch (result.Command)
                {
                    case Command.InvalidInput:
                        _consolePrinter.PrintMessage(result.Message);
                        continue;

                    case Command.Add:
                        var addedTask = _taskManager.AddTask(result.TaskRequest);
                        _consolePrinter.PrintTasks(addedTask.Tasks);
                        _consolePrinter.PrintMessage($"Задача {result.TaskRequest.Name} добавлена.");
                        continue;

                    case Command.Delete:
                        var deleteTask = _taskManager.DeleteTask(result.TaskRequest);
                        _consolePrinter.PrintTasks(deleteTask.Tasks);
                        _consolePrinter.PrintMessage($"Задача с ID {result.TaskRequest.Id} удалена.");
                        continue;

                    case Command.Update:
                        var updateTask = _taskManager.UpdateTask(result.TaskRequest);
                        _consolePrinter.PrintTasks(updateTask.Tasks);
                        _consolePrinter.PrintMessage($"Задача {result.TaskRequest.Name} обновлена.");
                        continue;

                    case Command.Exit:
                        _consolePrinter.PrintMessage("Выход из программы");
                        return;

                    case Command.Sort:
                       var sortTask =  _taskManager.SortTasks(result.SortRequest);
                        _consolePrinter.PrintTasks(sortTask.Tasks);
                        _consolePrinter.PrintMessage("Задачи отсортированы.");
                        continue;

                    case Command.Help:
                        _consolePrinter.PrintMessage(InstructionConstants.StartInstruction);
                        continue;
                }
            }
            catch (Exception ex)
            {
                _consolePrinter.PrintMessage(ex.Message);
            }
        }
    }
}
