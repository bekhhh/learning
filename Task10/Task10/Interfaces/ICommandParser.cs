using Task10.CommandParsing;

namespace Task10.Interfaces;

public interface ICommandParser
{
    CommandParsingResult ParseCommand(string input);
    string[] SplitSymbols(string input);
}