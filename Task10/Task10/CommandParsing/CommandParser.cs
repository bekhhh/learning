using System.Globalization;
using System.Text.RegularExpressions;
using Task10.Interfaces;
using Task10.Models;
using Task10.Requests;
using Task10.UserInteraction;
using Task = Task10.Models.Task;

namespace Task10.CommandParsing;

public class CommandParser : ICommandParser
{
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
                return new CommandParsingResult(Command.Help, message: InstructionConstants.StartInstruction + Environment.NewLine);
            default:
                return new CommandParsingResult(Command.InvalidInput,
                    $"Не удалось распознать команду {words[0]}.");
        }
    }
    private CommandParsingResult ParseAdd(string[] input)
    {
        var taskName = input[1];
        if (!Regex.IsMatch(taskName, "^[\x20-\x7E]+$"))
        {
            return new CommandParsingResult(Command.InvalidInput,
                "Название задачи должно состоять только из печатаемых символов ASCII.");
        }

        string? taskDescription = null;
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
        else
        {
            return new CommandParsingResult(Command.InvalidInput,
                "Описание задачи должно начинаться кавычкой.");
        }

        DateTime dateAndTime = DateTime.Now;
        int dateTimeIndex = descriptionEndIndex + 1;
        int priorityIndex = descriptionEndIndex + 1;
        
        if (dateTimeIndex < input.Length)
        {
            if (input[dateTimeIndex].StartsWith("\""))
            {
                int dateTimeEndIndex = Array.FindIndex(input, dateTimeIndex, x => x.EndsWith("\""));
                
                if (dateTimeEndIndex != -1)
                {
                    var dateTimeString = string.Join(" ", input.Skip(dateTimeIndex).Take(dateTimeEndIndex - dateTimeIndex + 1)).Trim('"');
                    
                    if (!DateTime.TryParse(dateTimeString, out dateAndTime))
                    {
                        return new CommandParsingResult(Command.InvalidInput, "Не удалось распознать дату и время.");
                    }
                    
                    priorityIndex = dateTimeEndIndex + 1;
                }
                else
                {
                    return new CommandParsingResult(Command.InvalidInput, "Дата и время должны заканчиваться кавычкой.");
                }
            }
        }

        var priority = Priority.Medium;
        if (priorityIndex < input.Length)
        {
            if (!Enum.TryParse<Priority>(input[priorityIndex], true, out var parsedPriority))
            {
                return new CommandParsingResult(Command.InvalidInput, 
                    $"Некорректный приоритет задачи. Допустимые значения: High, Medium, Low.");
            }
            priority = parsedPriority;
        }

        var newTaskRequest = new TaskRequest(taskName, dateAndTime, priority, taskDescription);
        return new CommandParsingResult(Command.Add, taskRequest: newTaskRequest);
    }
    
    private CommandParsingResult ParseUpdate(string[] input)
    {
        if (input.Length < 2 || !int.TryParse(input[1], out var taskId))
        {
            return new CommandParsingResult(Command.InvalidInput, "Не удалось распознать номер задачи.");
        }

        if (input.Length < 4)
        {
            return new CommandParsingResult(Command.InvalidInput,
                "Команда update должна содержать название, описание, дату и приоритет.");
        }
    
        var taskName = input[2];
        if (!Regex.IsMatch(taskName, "^[\x20-\x7E]+$"))
        {
            return new CommandParsingResult(Command.InvalidInput,
                "Название задачи должно состоять только из печатаемых символов ASCII.");
        }
    
        string? taskDescription = null;
        int descriptionEndIndex = -1;

        if (input[3].StartsWith("\""))
        {
            int descriptionStartIndex = 3;
            descriptionEndIndex = Array.FindIndex(input, descriptionStartIndex, x => x.EndsWith("\""));
            if (descriptionEndIndex != -1)
            {
                taskDescription = string.Join(" ", input.Skip(descriptionStartIndex).Take(descriptionEndIndex - descriptionStartIndex + 1)).Trim('"');
                if (!Regex.IsMatch(taskDescription, "^[\x20-\x7E]+$"))
                {
                    return new CommandParsingResult(Command.InvalidInput,
                        "Описание задачи должно состоять только из печатаемых символов ASCII.");
                }
            }
            else
            {
                return new CommandParsingResult(Command.InvalidInput,
                    "Описание задачи должно заканчиваться кавычкой.");
            }
        }
    
        DateTime dateAndTime = DateTime.Now;
        int dateTimeIndex = descriptionEndIndex + 1;
        int priorityIndex = descriptionEndIndex + 1;

        if (dateTimeIndex < input.Length)
        {
            if (input[dateTimeIndex].StartsWith("\""))
            {
                int dateTimeEndIndex = Array.FindIndex(input, dateTimeIndex, x => x.EndsWith("\""));
                if (dateTimeEndIndex != -1)
                {
                    var dateTimeString = string.Join(" ", input.Skip(dateTimeIndex).Take(dateTimeEndIndex - dateTimeIndex + 1)).Trim('"');
                    if (!DateTime.TryParse(dateTimeString, out dateAndTime))
                    {
                        return new CommandParsingResult(Command.InvalidInput, "Не удалось распознать дату и время.");
                    }
                    priorityIndex = dateTimeEndIndex + 1;
                }
                else
                {
                    return new CommandParsingResult(Command.InvalidInput, "Дата и время должны заканчиваться кавычкой.");
                }
            }
        }
    
        var priority = Priority.Medium;
        if (priorityIndex < input.Length)
        {
            if (!Enum.TryParse<Priority>(input[priorityIndex], true, out var parsedPriority))
            {
                return new CommandParsingResult(Command.InvalidInput,
                    $"Некорректный приоритет задачи. Допустимые значения: High, Medium, Low.");
            }
            priority = parsedPriority;
        }
    
        var updateTaskRequest = new TaskRequest(taskName, dateAndTime, priority, taskDescription, taskId);
        return new CommandParsingResult(Command.Update, taskRequest: updateTaskRequest);
    }

    private CommandParsingResult ParseDelete(string[] input)
    {
        if (input.Length < 2 || !int.TryParse(input[1], out var taskId))
        {
            return new CommandParsingResult(Command.InvalidInput, "Не удалось распознать номер задачи.");
        }

        var deleteTaskRequest = new TaskRequest(id: taskId);
        return new CommandParsingResult(Command.Delete, taskRequest: deleteTaskRequest);
    }
    
    private CommandParsingResult ParseSort(string[] input)
    {
        if (input.Length < 2)
        {
            return new CommandParsingResult(Command.InvalidInput, "Не удалось распознать команду.");
        }
        var field = input[1].ToLower();
        var direction = input.Length > 2 ? input[2].ToLower() switch
        {
            "asc" => true,
            "desc" => false,
            _ => (bool?)null
        } : true;

        if (direction == null)
        {
            return new CommandParsingResult(Command.InvalidInput, $"Не удалось распознать направление сортировки: {input[2]}.");
        }

        var newSortRequest = new SortRequest(field, direction.Value);
        return new CommandParsingResult(Command.Sort, sortRequest: newSortRequest);
    }
}