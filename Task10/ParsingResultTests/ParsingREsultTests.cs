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
        //Arrange            
        string input = "add xuy \"ejednevnaya drochka  add fasdh fsdhai\" 31:12:21 23:59:59 +03:00 Low";

        //Act
        var result = _parser.ParseCommand(input);

        //Assert
        Assert.Equal(Command.Add, result.Command);
        Assert.Equal("xuy", result.TaskRequest.Name);
        Assert.Equal(Priority.Low, result.TaskRequest.Priority);
    }
    
    [Fact]
    public void Test_WhenDescriptionIsNull()
    {
        //Arrange            
        string input = "add drochka 31:12:21 23:59:59 +03:00 High";

        //Act
        var result = _parser.ParseCommand(input);

        //Assert
        Assert.Equal(Command.Add, result.Command);
    }
    
    [Fact]
    public void Test_WhenPriorityIsNull()
    {
        //Arrange            
        string input = "add drochka \"ejednevnaya drochka\" 31:12:21 23:59:59 +03:00";

        //Act
        var result = _parser.ParseCommand(input);

        //Assert
        Assert.Equal(Command.Add, result.Command);
    }
    
    [Fact]
    public void Test_WhenPriorityAndDescriptionAreNull()
    {
        //Arrange            
        string input = "add drochka 31:12:21 23:59:59 +03:00";

        //Act
        var result = _parser.ParseCommand(input);

        //Assert
        Assert.Equal(Command.Add, result.Command);
    }

    [Fact]
    public void TryParse_WhenInputIs_Empty()
    {
        //Arrange            
        string input = "";

        //Act
        var result = _parser.ParseCommand(input);

        //Assert
        Assert.Equal(Command.InvalidInput, result.Command);
    }

    [Fact]
    public void Test_WhenFirstWordAdd()
    {
        //Arrange
        string input = "add";

        //Act
        var result = _parser.ParseCommand(input);

        //Assert
        Assert.Equal(Command.InvalidInput, result.Command);
    }
    
    [Fact]
    public void Test_NameOfTask_ForASCII()
    {
        //Arrange
        string input = "add залупа";

        //Act
        var result = _parser.ParseCommand(input);

        //Assert
        Assert.Equal(Command.InvalidInput, result.Command);
    }
    
    [Fact]
    public void Test_DescriptionOfTask_ForASCII()
    {
        //Arrange
        string input = "add name \"залупа полнейшая\" ";

        //Act
        var result = _parser.ParseCommand(input);

        //Assert
        Assert.Equal(Command.InvalidInput, result.Command);
    }
    
    [Fact]
    public void Test_DescriptionOfTask_WithoutQuotes()
    {
        //Arrange
        string input = "add name залупа полнейшая ";

        //Act
        var result = _parser.ParseCommand(input);

        //Assert
        Assert.Equal(Command.InvalidInput, result.Command);
    }
    
    [Fact]
    public void Test_DateAndTimeInIncorrentFormat()
    {
        //Arrange            
        string input = "add drochka \" ejednevnaya drochka \" 31:12:21 23:59:59 +03:00 High";

        //Act
        var result = _parser.ParseCommand(input);

        //Assert
        Assert.Equal(Command.InvalidInput, result.Command);
    }
    
    [Fact]
    public void Test_WhenPriorityIsInvalid()
    {
        //Arrange            
        string input = "add drochka \" ejednevnaya drochka \" 31:12:21 23:59:59 +03:00 zalupa";

        //Act
        var result = _parser.ParseCommand(input);

        //Assert
        Assert.Equal(Command.InvalidInput, result.Command);
    }
    
    [Fact]
    public void Test_DeleteByIndex()
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
        string input = "update 1 NewTask \"New Description\" 31:12:21 23:59:59 +03:00 Low";

        // Act
        var result = _parser.ParseCommand(input);

        // Assert
        Assert.Equal(Command.Update, result.Command);
        Assert.Equal("NewTask", result.TaskRequest.Name);
        Assert.Equal("New Description", result.TaskRequest.Description);
        Assert.Equal(Priority.Low, result.TaskRequest.Priority);
    }
}
    
    
