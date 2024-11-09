using System.Globalization;
using Task10.CommandParsing;
using Task10.Interfaces;
using Task10.Models;
using Xunit;
using Assert = Xunit.Assert;

namespace ParsingResultTest;

public class ParsingResultTest
{
    private ICommandParser _parser;

    public ParsingResultTest()
    {
        _parser = new CommandParser();
    }

    [Fact]
    public void Test_WhenEverythingIsRight()
    {
        // Arrange
        string input = "add task_name \"task description\" \"31.12.2021 23:59:59\" Low";

        // Act
        var result = _parser.ParseCommand(input);

        // Assert
        Assert.Equal(Command.Add, result.Command);
        Assert.Equal("task_name", result.TaskRequest.Name);
        Assert.Equal("task description", result.TaskRequest.Description);
        Assert.Equal(Priority.Low, result.TaskRequest.Priority);
    }

    [Fact]
    public void Test_WhenPriorityIsDefault()
    {
        // Arrange
        string input = "add task_name \"task description\" \"31.12.2021 23:59:59\"";

        // Act
        var result = _parser.ParseCommand(input);

        // Assert
        Assert.Equal(Command.Add, result.Command);
        Assert.Equal("task_name", result.TaskRequest.Name);
        Assert.Equal("task description", result.TaskRequest.Description);
        Assert.Equal(Priority.Medium, result.TaskRequest.Priority);
    }

    [Fact]
    public void Test_WhenDateAndPriorityIsDefault()
    {
        // Arrange
        string input = "add task_name \"task description\"";

        // Act
        var result = _parser.ParseCommand(input);

        // Assert
        Assert.Equal(Command.Add, result.Command);
        Assert.Equal("task_name", result.TaskRequest.Name);
        Assert.Equal("task description", result.TaskRequest.Description);
        Assert.Equal(Priority.Medium, result.TaskRequest.Priority);
    }
    
    [Fact]
    public void Test_WhenDateIsDefault()
    {
        // Arrange
        string input = "add task_name \"task description\" High";

        // Act
        var result = _parser.ParseCommand(input);

        // Assert
        Assert.Equal(Command.Add, result.Command);
        Assert.Equal("task_name", result.TaskRequest.Name);
        Assert.Equal("task description", result.TaskRequest.Description);
        Assert.Equal(Priority.High, result.TaskRequest.Priority);
    }

    [Fact]
    public void Test_WhenInputIsEmpty()
    {
        // Arrange
        string input = "";

        // Act
        var result = _parser.ParseCommand(input);

        // Assert
        Assert.Equal(Command.InvalidInput, result.Command);
    }

    [Fact]
    public void Test_InvalidName_NonAscii()
    {
        // Arrange
        string input = "add не_ascii_name \"task description\" [31.12.2021 23:59:59 +03:00] Low";

        // Act
        var result = _parser.ParseCommand(input);

        // Assert
        Assert.Equal(Command.InvalidInput, result.Command);
    }

    [Fact]
    public void Test_DescriptionMissingQuotes()
    {
        // Arrange
        string input = "add task_name task description [31.12.2021 23:59:59 +03:00] Low";

        // Act
        var result = _parser.ParseCommand(input);

        // Assert
        Assert.Equal(Command.InvalidInput, result.Command);
    }

    [Fact]
    public void Test_InvalidDateFormat()
    {
        // Arrange
        string input = "add task_name \"task description\" [31.12.2021 23:59:59 +03:00] Low";

        // Act
        var result = _parser.ParseCommand(input);

        // Assert
        Assert.Equal(Command.InvalidInput, result.Command);
    }

    [Fact]
    public void Test_InvalidPriority()
    {
        // Arrange
        string input = "add task_name \"task description\" \"31.12.2021 23:59:59\" invalid_priority";

        // Act
        var result = _parser.ParseCommand(input);

        // Assert
        Assert.Equal(Command.InvalidInput, result.Command);
    }

    [Fact]
    public void Test_DeleteCommandByIndex()
    {
        // Arrange
        string deleteContent = "delete 1";

        // Act
        var result = _parser.ParseCommand(deleteContent);

        // Assert
        Assert.Equal(Command.Delete, result.Command);
    }

    [Fact]
    public void Test_UpdateTask_Success()
    {
        // Arrange
        string input = "update 1 NewTask \"New Description\" \"31.12.2021 23:59:59\" Low";

        // Act
        var result = _parser.ParseCommand(input);

        // Assert
        Assert.Equal(Command.Update, result.Command);
        Assert.Equal("NewTask", result.TaskRequest.Name);
        Assert.Equal("New Description", result.TaskRequest.Description);
        Assert.Equal(Priority.Low, result.TaskRequest.Priority);
    }
}