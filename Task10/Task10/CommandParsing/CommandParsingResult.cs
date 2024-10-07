using Task10.Models;
using Task10.Requests;
using Task = Task10.Models.Task;

namespace Task10.CommandParsing;

public class CommandParsingResult
{
    public Command Command { get; }
    public string? Message { get; }
    public TaskRequest? TaskRequest { get; set; }
    public SortRequest? SortRequest { get; set; }
    public int Id { get; set; }

    public CommandParsingResult(Command command, string? message = null, TaskRequest? taskRequest = null,
        int id = 0, SortRequest? sortRequest = null)

    {
        Command = command;
        TaskRequest = taskRequest;
        Message = message;
        Id = id;
        SortRequest = sortRequest;
    }
}