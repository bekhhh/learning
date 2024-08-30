using Task10.CommandParsing;

namespace Task10.UserInteraction;

public class InputHandler
{
    public CommandParser Parser { get; }
    public TaskManager TaskManager { get; }

    public InputHandler()
    {
        TaskManager = new TaskManager();
        Parser = new CommandParser(TaskManager);  // Передаем TaskManager в CommandParser
    }

    public void HandlerInput()
    {
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
                        Console.WriteLine($"Задача {result.Task.Name} добавлена.");                            
                        continue;
                    case Command.View:
                        TaskManager.PrintJson();
                        continue;
                    case Command.Delete:
                        TaskManager.Tasks.Remove(result.Task);
                        Console.WriteLine($"Задача под номером {result.Task.Id} удалена.");
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