using Task10.CommandParsing;
using Task10.FileManager;

namespace Task10.UserInteraction;

public class InputHandler
{
    public CommandParser Parser { get; }
    public ConsolePrinter ConsolePrinter { get; }
    public TaskManager TaskManager { get; }
    public FileWriter FileWriter { get; }

    public InputHandler()
    {
        TaskManager = new TaskManager();
        ConsolePrinter = new ConsolePrinter();
        Parser = new CommandParser(TaskManager,FileWriter,ConsolePrinter);
        FileWriter = new FileWriter(TaskManager); 
    }

    public void HandlerInput()
    {
        Console.WriteLine(TaskManagerInstructions.GeneralInstruction);
        while (true)
        {
            try
            {
                var input = Console.ReadLine();
                var result = Parser.ParseCommand(input);
                switch (result.Command)
                {
                    case Command.InvalidInput:
                        Console.WriteLine(result.Message);
                        continue;

                    case Command.Add:
                        TaskManager.Tasks.Add(result.Task);
                        FileWriter.WriteTasksToFile();
                        ConsolePrinter.PrintTasks(TaskManager.Tasks); 
                        Console.WriteLine($"Задача {result.Task.Name} добавлена.");
                        continue;

                    case Command.Delete:
                        TaskManager.Tasks.Remove(result.Task);
                        FileWriter.WriteTasksToFile();
                        ConsolePrinter.PrintTasks(TaskManager.Tasks); 
                        Console.WriteLine($"Задача под номером {result.Task.Id} удалена.");
                        continue;

                    case Command.Exit:
                        FileWriter.WriteTasksToFile();
                        Console.WriteLine("Выход из программы.");
                        return;

                    case Command.Sort:
                        FileWriter.WriteTasksToFile(); 
                        ConsolePrinter.PrintTasks(TaskManager.Tasks); 
                        Console.WriteLine("Задачи отсортированы.");
                        continue;

                    case Command.Update:
                        FileWriter.WriteTasksToFile();
                        ConsolePrinter.PrintTasks(TaskManager.Tasks); 
                        Console.WriteLine($"Задача под номером {result.Task.Id} обновлена.");
                        continue;

                    case Command.Help:
                        Console.WriteLine(result.Message);
                        continue;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
