using Task10;
using Task10.CommandParsing;
using Task10.FileManager;
using Task10.UserInteraction;

var consolePrinter = new ConsolePrinter();
var taskManager = new TaskManager();
var commandParser = new CommandParser(taskManager);
var inputHandler = new InputHandler(commandParser, consolePrinter, taskManager);
inputHandler.HandleInput();