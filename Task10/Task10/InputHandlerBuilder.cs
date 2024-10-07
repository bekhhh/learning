using Task10.CommandParsing;
using Task10.FileManager;
using Task10.Models;
using Task10.UserInteraction;

namespace Task10;

public class InputHandlerBuilder
{
    public InputHandler Build()
    {
        var consolePrinter = new ConsolePrinter();
        var commandParser = new CommandParser();
        var taskRepository = new TasksRepository(consolePrinter);
        var storageData = new StorageData();
        var taskManager = new TaskManager(taskRepository, consolePrinter, storageData);
        var inputHandler = new InputHandler(commandParser, consolePrinter, taskManager, taskRepository);

        return inputHandler;
    }
}