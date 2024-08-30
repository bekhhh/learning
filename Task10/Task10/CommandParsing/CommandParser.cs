using System.Globalization;
using System.Text.RegularExpressions;

namespace Task10.CommandParsing;

public class CommandParser
{
    private int _nextTaskId;
    private TaskManager TaskManager { get; }

    public CommandParser(TaskManager taskManager)
    {
        TaskManager = taskManager;
    }

    public CommandParsingResult ParseCommand(string input)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
        {
            return new CommandParsingResult(Command.InvalidInput,
                "Не получилось распознать команду. Введите строку в нужном формате.");
        }
        var words = input.Split(' ')
            .Select(x => x.Trim())
            .Where(x => !string.IsNullOrEmpty(x))
            .ToArray();
        switch (words[0])
        {
            case "add":
                return ParseAdd(words);
            case "delete":
                return ParseDelete(words);
            case "update":
                return ParseUpdate(words);
            case "view":
                return ParseView(words);
            default:
                return new CommandParsingResult(Command.InvalidInput,
                    $"Не удалось распознать команду {words[0]}.");
        }
    }
    private CommandParsingResult ParseAdd(string[] input)
    {
        if (input.Length < 5)
        {
            return new CommandParsingResult(Command.InvalidInput,
                "Команда add состоит минимум из 5 частей, введите команду в нужном формате.");
        }

        var taskName = input[1];
        if (!Regex.IsMatch(taskName, "^[\x20-\x7E]+$"))
        {
            return new CommandParsingResult(Command.InvalidInput,
                "Название задачи должно состоять только из печатаемых символов ASCII.");
        }

        string taskDescription = null;
        int descriptionEndIndex = -1;

        if (input[2].StartsWith("\""))
        {
            var descriptionStartIndex = 2;
            descriptionEndIndex = Array.FindIndex(input, descriptionStartIndex, x => x.EndsWith("\""));
            if (descriptionEndIndex != -1)
            {
                taskDescription = string.Join(" ", input.Skip(descriptionStartIndex).Take(descriptionEndIndex - descriptionStartIndex + 1));
                taskDescription = taskDescription.Trim('"');
                if (!Regex.IsMatch(taskDescription, "^[\x20-\x7E]+$"))
                {
                    return new CommandParsingResult(Command.InvalidInput,
                        "Описание задачи должно состоять только из печатаемых символов ASCII, включая пробелы.");
                }
            }
            else
            {
                return new CommandParsingResult(Command.InvalidInput,
                    "Описание задачи должно заканчиваться кавычкой.");
            }
        }

        var dateTimeIndex = descriptionEndIndex == -1 ? 2 : descriptionEndIndex + 1;
        if (dateTimeIndex + 2 >= input.Length)
        {
            return new CommandParsingResult(Command.InvalidInput, "Отсутствуют параметры даты и времени.");
        }

        var dateTimeInput = input.Skip(dateTimeIndex).Take(3).ToArray();
        if (!DateTime.TryParseExact(string.Join(" ", dateTimeInput),
                "dd.MM.yy HH.mm.ss zzz",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var dateTime))
        {
            return new CommandParsingResult(Command.InvalidInput, "Неверный формат даты и времени.");
        }

        var priorityInputIndex = dateTimeIndex + 3;
        var priorityInput = priorityInputIndex < input.Length ? input[priorityInputIndex] : null;
        if (string.IsNullOrEmpty(priorityInput) || !Enum.TryParse<PriorityType>(priorityInput, true, out var priority))
        {
            priority = PriorityType.Medium;
        }

        var newTask = new Task(_nextTaskId++, taskName, dateTime, priority, taskDescription);
        return new CommandParsingResult(Command.Add, task: newTask);
    }

    private CommandParsingResult ParseDelete(string[] input)
    {
        if (input.Length < 2 || !int.TryParse(input[1], out var taskId))
        {
            return new CommandParsingResult(Command.InvalidInput, "Не удалось распознать номер задачи.");
        }

        var task = TaskManager.Tasks.FirstOrDefault(t => t.Id == taskId);
        if (task == null)
        {
            return new CommandParsingResult(Command.InvalidInput, $"Задача с номером {taskId} не найдена.");
        }
        return new CommandParsingResult(Command.Delete, task: task);
    }
    
    private CommandParsingResult ParseUpdate(string [] input)
    {
        if (input.Length != 1)
        {
            return new CommandParsingResult(Command.InvalidInput, 
                "Команда update состоит из одного слова");
        }
        return new CommandParsingResult(Command.Update);
    }
    
    private CommandParsingResult ParseView(string [] input)
    {
        
        return new CommandParsingResult(Command.View);
    }
}