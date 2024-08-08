using Task9.Сharacters.Ability;

namespace Task9.UserInput.CommandParsing
{
    public class CommandParsingResult
    {
        public Command Command { get; }
        public string? Message { get; }
        public Ability? Ability { get; }
        public Character? Character { get; }
        public CommandParsingResult(Command command, string? message = null, Ability? ability = null, Character? character = null)
        {
            Command = command;
            Message = message;
            Ability = ability;
            Character = character;
        }
    }
}
