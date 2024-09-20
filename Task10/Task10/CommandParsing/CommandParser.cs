using System.Globalization;
using System.Text.RegularExpressions;
using Task10.FileManager;

namespace Task10.CommandParsing;

public class CommandParser()
{
    private int _nextTaskId = 1;
    private TaskManager TaskManager { get; }
    public FileWriter FileWriter { get; }
    public ConsolePrinter ConsolePrinter { get; }

    public CommandParser(TaskManager taskManager, FileWriter fileWriter, ConsolePrinter consolePrinter) : this()
    {
        TaskManager = taskManager;
        FileWriter = fileWriter;
        ConsolePrinter = consolePrinter;
    }

    public CommandParsingResult ParseCommand(string input)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine(TaskManagerInstructions.GeneralInstruction + Environment.NewLine);
            return new CommandParsingResult(Command.InvalidInput,
                "Не получилось распознать команду. Введите строку в нужном формате.");
        }
        var words = input.Split(' ')
            .Select(x => x.Trim())
            .Where(x => !string.IsNullOrEmpty(x))
            .ToArray();
        switch (words[0].ToLower())
        {
            case "add":
                return ParseAdd(words);
            case "delete":
                return ParseDelete(words);
            case "update":
                return ParseUpdate(words);
            case "sort":
                return ParseSort(words);
            case "exit":
                return new CommandParsingResult(Command.Exit);
            case "help":
                return new CommandParsingResult(Command.Help, message: TaskManagerInstructions.GeneralInstruction + Environment.NewLine);
            default:
                return new CommandParsingResult(Command.InvalidInput,
                    $"Не удалось распознать команду {words[0]}.");
        }
    }
    private CommandParsingResult ParseAdd(string[] input)
    {
        if (input.Length < 5)
        {
            Console.WriteLine(TaskManagerInstructions.AddTaskInstruction + Environment.NewLine);
            return new CommandParsingResult(Command.InvalidInput,
                "Команда add состоит минимум из 5 частей, введите команду в нужном формате.");
        }

        var taskName = input[1];
        if (!Regex.IsMatch(taskName, "^[\x20-\x7E]+$"))
        {
            Console.WriteLine(TaskManagerInstructions.AddTaskInstruction + Environment.NewLine);
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
                    Console.WriteLine(TaskManagerInstructions.AddTaskInstruction + Environment.NewLine);
                    return new CommandParsingResult(Command.InvalidInput,
                        "Описание задачи должно состоять только из печатаемых символов ASCII, включая пробелы.");
                }
            }
            else
            {
                Console.WriteLine(TaskManagerInstructions.AddTaskInstruction + Environment.NewLine);
                return new CommandParsingResult(Command.InvalidInput,
                    "Описание задачи должно заканчиваться кавычкой.");
            }
        }

        var dateTimeIndex = descriptionEndIndex == -1 ? 2 : descriptionEndIndex + 1;
        if (dateTimeIndex + 2 >= input.Length)
        {
            Console.WriteLine(TaskManagerInstructions.AddTaskInstruction + Environment.NewLine);
            return new CommandParsingResult(Command.InvalidInput, "Отсутствуют параметры даты и времени.");
        }

        var dateTimeInput = input.Skip(dateTimeIndex).Take(3).ToArray();
        if (!DateTime.TryParseExact(string.Join(" ", dateTimeInput),
                "dd.MM.yy HH.mm.ss zzz",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var dateTime))
        {
            Console.WriteLine(TaskManagerInstructions.AddTaskInstruction + Environment.NewLine);
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
            Console.WriteLine(TaskManagerInstructions.DeleteTaskInstruction + Environment.NewLine);
            return new CommandParsingResult(Command.InvalidInput, "Не удалось распознать номер задачи.");
        }

        var task = TaskManager.Tasks.FirstOrDefault(t => t.Id == taskId);
        if (task == null)
        {
            Console.WriteLine(TaskManagerInstructions.DeleteTaskInstruction + Environment.NewLine);
            return new CommandParsingResult(Command.InvalidInput, $"Задача с номером {taskId} не найдена.");
        }
        return new CommandParsingResult(Command.Delete, task: task);
    }
    
    private CommandParsingResult ParseUpdate(string[] input)
    {
        if (input.Length < 2 || !int.TryParse(input[1], out var taskId))
        {
            Console.WriteLine(TaskManagerInstructions.UpdateTaskInstruction + Environment.NewLine);
            return new CommandParsingResult(Command.InvalidInput, "Не удалось распознать номер задачи.");
        }

        var task = TaskManager.Tasks.FirstOrDefault(t => t.Id == taskId);
        if (task == null)
        {
            Console.WriteLine(TaskManagerInstructions.UpdateTaskInstruction + Environment.NewLine);
            return new CommandParsingResult(Command.InvalidInput, $"Задача с номером {taskId} не найдена.");
        }

        if (input.Length < 5)
        {
            Console.WriteLine(TaskManagerInstructions.UpdateTaskInstruction + Environment.NewLine);
            return new CommandParsingResult(Command.InvalidInput,
                "Команда update состоит минимум из 5 частей, введите команду в нужном формате.");
        }

        var taskName = input[2];
        if (!Regex.IsMatch(taskName, "^[\x20-\x7E]+$"))
        {
            Console.WriteLine(TaskManagerInstructions.UpdateTaskInstruction + Environment.NewLine);
            return new CommandParsingResult(Command.InvalidInput,
                "Название задачи должно состоять только из печатаемых символов ASCII.");
        }

        string taskDescription = null;
        int descriptionEndIndex = -1;

        if (input[3].StartsWith("\""))
        {
            var descriptionStartIndex = 3;
            descriptionEndIndex = Array.FindIndex(input, descriptionStartIndex, x => x.EndsWith("\""));
            if (descriptionEndIndex != -1)
            {
                taskDescription = string.Join(" ", input.Skip(descriptionStartIndex).Take(descriptionEndIndex - descriptionStartIndex + 1));
                taskDescription = taskDescription.Trim('"');
                if (!Regex.IsMatch(taskDescription, "^[\x20-\x7E]+$"))
                {
                    Console.WriteLine(TaskManagerInstructions.UpdateTaskInstruction + Environment.NewLine);
                    return new CommandParsingResult(Command.InvalidInput,
                        "Описание задачи должно состоять только из печатаемых символов ASCII, включая пробелы.");
                }
            }
            else
            {
                Console.WriteLine(TaskManagerInstructions.UpdateTaskInstruction + Environment.NewLine);
                return new CommandParsingResult(Command.InvalidInput,
                    "Описание задачи должно заканчиваться кавычкой.");
            }
        }

        var dateTimeIndex = descriptionEndIndex == -1 ? 3 : descriptionEndIndex + 1;
        if (dateTimeIndex + 2 >= input.Length)
        {
            Console.WriteLine(TaskManagerInstructions.UpdateTaskInstruction + Environment.NewLine);
            return new CommandParsingResult(Command.InvalidInput, "Отсутствуют параметры даты и времени.");
        }

        var dateTimeInput = input.Skip(dateTimeIndex).Take(3).ToArray();
        if (!DateTime.TryParseExact(string.Join(" ", dateTimeInput),
                "dd.MM.yy HH.mm.ss zzz",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var dateTime))
        {
            Console.WriteLine(TaskManagerInstructions.UpdateTaskInstruction + Environment.NewLine);
            return new CommandParsingResult(Command.InvalidInput, "Неверный формат даты и времени.");
        }

        var priorityInputIndex = dateTimeIndex + 3;
        var priorityInput = priorityInputIndex < input.Length ? input[priorityInputIndex] : null;
        if (string.IsNullOrEmpty(priorityInput) || !Enum.TryParse<PriorityType>(priorityInput, true, out var priority))
        {
            priority = PriorityType.Medium;
        }
        var updatedTask = new Task(taskId, taskName, dateTime, priority, taskDescription);
        TaskManager.Tasks.Remove(task); 
        TaskManager.Tasks.Add(updatedTask); 

        return new CommandParsingResult(Command.Update, task: updatedTask);
    }

    private CommandParsingResult ParseSort(string[] input)
    {
        if (TaskManager.Tasks.Count < 2)
        {
            Console.WriteLine(TaskManagerInstructions.SortTaskInstruction + Environment.NewLine);
            return new CommandParsingResult(Command.InvalidInput, "Сортировка невозможна: недостаточно задач.");
        }
    
        if (input.Length < 3)
        {
            Console.WriteLine(TaskManagerInstructions.SortTaskInstruction + Environment.NewLine);
            return new CommandParsingResult(Command.InvalidInput, "Не удалось распознать команду.");
        }

        var sorter = new Sorter(TaskManager);
        switch (input[1].ToLower())
        {
            case "name":
                if (input[2].ToLower() == "asc")
                {
                    sorter.SortByNameAsc();
                }
                else if (input[2].ToLower() == "desc")
                {
                    sorter.SortByNameDesc();
                }
                else
                {
                    Console.WriteLine(TaskManagerInstructions.SortTaskInstruction + Environment.NewLine);
                    return new CommandParsingResult(Command.InvalidInput, $"Не удалось распознать направление сортировки {input[2]} для имени.");
                }
                break;
            case "date":
                if (input[2].ToLower() == "asc")
                {
                    sorter.SortByDateAsc();
                }
                else if (input[2].ToLower() == "desc")
                {
                    sorter.SortByDateDesc();
                }
                else
                {
                    Console.WriteLine(TaskManagerInstructions.SortTaskInstruction + Environment.NewLine);
                    return new CommandParsingResult(Command.InvalidInput, $"Не удалось распознать направление сортировки {input[2]} для даты.");
                }
                break;
            case "priority":
                if (input[2].ToLower() == "asc")
                {
                    sorter.SortByPriorityAsc();
                }
                else if (input[2].ToLower() == "desc")
                {
                    sorter.SortByPriorityDesc();
                }
                else
                {
                    Console.WriteLine(TaskManagerInstructions.SortTaskInstruction + Environment.NewLine);
                    return new CommandParsingResult(Command.InvalidInput, $"Не удалось распознать направление сортировки {input[2]} для приоритета.");
                }
                break;
            case "id":
                if (input[2].ToLower() == "asc")
                {
                    sorter.SortByIdAsc();
                }
                else if (input[2].ToLower() == "desc")
                {
                    sorter.SortByIdDesc();
                }
                else
                {
                    Console.WriteLine(TaskManagerInstructions.SortTaskInstruction + Environment.NewLine);
                    return new CommandParsingResult(Command.InvalidInput, $"Не удалось распознать направление сортировки {input[2]} для ID.");
                }
                break;
            default:
                Console.WriteLine(TaskManagerInstructions.SortTaskInstruction + Environment.NewLine);
                return new CommandParsingResult(Command.InvalidInput, $"Не удалось распознать параметр {input[1]} для сортировки.");
        }
        return new CommandParsingResult(Command.Sort);
    }
}