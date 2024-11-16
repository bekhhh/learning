using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Task10.Interfaces;
using Task10.Models;
using Task10.Requests;
using Task10.UserInteraction;
using Task = Task10.Models.Task;

namespace Task10.CommandParsing;

public class CommandParser : ICommandParser
{
    private readonly List<string> _inputParts = new();
    private readonly StringBuilder _currentPart = new();
    private bool _startQuotes;
    
    public CommandParsingResult ParseCommand(string input)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
        {
            return new CommandParsingResult(Command.InvalidInput,
                "Не получилось распознать команду. Введите строку в нужном формате.");
        }

        foreach (var symbol in input)
        {
            if (symbol == '"')
            {
                _currentPart.Append(symbol);
                if (_startQuotes)
                {
                    _inputParts.Add(_currentPart.ToString());
                    _currentPart.Clear();
                }
                _startQuotes =!_startQuotes;
            }
            else if (!_startQuotes && char.IsWhiteSpace(symbol))
            {
                if (_currentPart.Length == 0)
                {
                    continue;
                }
                _inputParts.Add(_currentPart.ToString());
                _currentPart.Clear();
            }
            else
            {
                _currentPart.Append(symbol);
            }
        }

        if (_currentPart.Length != 0)
        {
            _inputParts.Add(_currentPart.ToString());
        }

        var inputArray = _inputParts.ToArray();
        switch (inputArray[0])
        {
            case "add":
                return ParseAdd(inputArray);
            case "delete":
                return ParseDelete(inputArray);
            case "update":
                return ParseUpdate(inputArray);
            case "sort":
                return ParseSort(inputArray);
            case "exit":
                return new CommandParsingResult(Command.Exit);
            case "help":
                return new CommandParsingResult(Command.Help, message: InstructionConstants.StartInstruction + Environment.NewLine);
            default:
                return new CommandParsingResult(Command.InvalidInput,
                    $"Не удалось распознать команду {inputArray[0]}.");
        }
    }
    private CommandParsingResult ParseAdd(string[] input)
    {
        return ParseTask(input, isUpdate: false);
    }

    private CommandParsingResult ParseUpdate(string[] input)
    {
        if (input.Length < 2 || !int.TryParse(input[1], out var taskId))
        {
            return new CommandParsingResult(Command.InvalidInput, "Не удалось распознать номер задачи.");
        }

        return ParseTask(input, isUpdate: true, taskId);
    }

    private CommandParsingResult ParseTask(string[] input, bool isUpdate = false, int taskId = -1)
    {
        int startIndex = isUpdate ? 2 : 1;
    
        if (startIndex >= input.Length)
        {
            return new CommandParsingResult(Command.InvalidInput, "Отсутствует название задачи.");
        }

        var taskName = input[startIndex];
        if (!Regex.IsMatch(taskName, "^[\x20-\x7E]+$"))
        {
            return new CommandParsingResult(Command.InvalidInput, "Название задачи должно состоять только из печатаемых символов ASCII.");
        }
    
        string? taskDescription = null;
        int descriptionEndIndex = -1;

        if (startIndex + 1 < input.Length && input[startIndex + 1].StartsWith("\""))
        {
            var descriptionStartIndex = startIndex + 1;
            descriptionEndIndex = Array.FindIndex(input, descriptionStartIndex, x => x.EndsWith("\""));
            if (descriptionEndIndex != -1)
            {
                taskDescription = string.Join(" ", input.Skip(descriptionStartIndex).Take(descriptionEndIndex - descriptionStartIndex + 1)).Trim('"');
                if (!Regex.IsMatch(taskDescription, "^[\x20-\x7E]+$"))
                {
                    return new CommandParsingResult(Command.InvalidInput, "Описание задачи должно состоять только из печатаемых символов ASCII.");
                }
            }
            else
            {
                return new CommandParsingResult(Command.InvalidInput, "Описание задачи должно заканчиваться кавычкой.");
            }
        }
    
        DateTime dateAndTime = DateTime.Now;
        int dateTimeIndex = descriptionEndIndex != -1 ? descriptionEndIndex + 1 : startIndex + 1;
        int priorityIndex = dateTimeIndex;

        if (dateTimeIndex < input.Length && input[dateTimeIndex].StartsWith("\""))
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
    
        var priority = Priority.Medium;
        if (priorityIndex < input.Length)
        {
            if (!Enum.TryParse<Priority>(input[priorityIndex], true, out var parsedPriority))
            {
                return new CommandParsingResult(Command.InvalidInput, "Некорректный приоритет задачи. Допустимые значения: High, Medium, Low.");
            }
            priority = parsedPriority;
        }
    
        var taskRequest = new TaskRequest(taskName, dateAndTime, priority, taskDescription, taskId);
        return isUpdate
            ? new CommandParsingResult(Command.Update, taskRequest: taskRequest)
            : new CommandParsingResult(Command.Add, taskRequest: taskRequest);
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