namespace Task10.CommandParsing;

public class CommandParsingResult
{
    public Command Command { get; }
    public string? Message { get; }
    public Task? Task { get; }

    public CommandParsingResult(Command command, string? message = null, Task? task = null)
    {
        Command = command;
        Message = message;
        Task = task;
    }
}  
