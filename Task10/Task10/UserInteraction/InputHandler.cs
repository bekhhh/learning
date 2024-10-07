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
        _taskRepository.LoadTasks();
        _taskRepository.PrintTasks();
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
                        _taskManager.AddTask(result.TaskRequest);
                        continue;

                    case Command.Delete:
                        _taskManager.DeleteTask(result.TaskRequest);
                        continue;
                    
                    case Command.Update:
                        _taskManager.UpdateTask(result.TaskRequest);
                        continue;

                    case Command.Exit:
                        _taskManager.ExitApplication();
                        return;

                    case Command.Sort:
                        _taskManager.SortTasks(result.SortRequest);
                        continue;

                    case Command.Help:
                        _taskManager.HelpMessage();
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
