using Task10.CommandParsing;
using Task10.FileManager;
using Task10.UserInteraction;

namespace Task10;

public class InputHandlerBuilder
{
    public InputHandler Build()
    {
        var commandParser = new CommandParser();
        var consolePrinter = new ConsolePrinter();
        var taskRepository = new TasksRepository();
        var taskManager = new TaskManager(taskRepository);
        var inputHandler = new InputHandler(commandParser, consolePrinter, taskManager, taskRepository);

        return inputHandler;
    }
}