using Task10;
using Task10.CommandParsing;
using Xunit;
using Assert = Xunit.Assert;

namespace ParsingResultTest;

public class ParsingResultTest
{
    private readonly CommandParser _parser;
    private readonly TaskManager _taskManager;

    public ParsingResultTest()
    {
        _taskManager = new TaskManager(); 
        _parser = new CommandParser(_taskManager); 
    }
    
    [Fact]
    public void Test_WhenEverythingIsRight()
    {
        //Arrange            
        string input = "add xuy \"ejednevnaya drochka  add fasdh fsdhai\" 31.12.21 23.59.59 +03:00 Low";

        //Act
        var result = _parser.ParseCommand(input);

        //Assert
        Assert.Equal(Command.Add, result.Command);
        Assert.Equal("xuy", result.Task.Name);
        Assert.Equal(PriorityType.Low, result.Task.Priority);
    }
    
    [Fact]
    public void Test_WhenDescriptionIsNull()
    {
        //Arrange            
        string input = "add drochka 31.12.21 23.59.59 +03:00 High";

        //Act
        var result = _parser.ParseCommand(input);

        //Assert
        Assert.Equal(Command.Add, result.Command);
    }
    
    [Fact]
    public void Test_WhenPriorityIsNull()
    {
        //Arrange            
        string input = "add drochka \"ejednevnaya drochka\" 31.12.21 23.59.59 +03:00";

        //Act
        var result = _parser.ParseCommand(input);

        //Assert
        Assert.Equal(Command.Add, result.Command);
    }
    
    [Fact]
    public void Test_WhenPriorityAndDescriptionAreNull()
    {
        //Arrange            
        string input = "add drochka 31.12.21 23.59.59 +03:00";

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
        string input = "add drochka \" ejednevnaya drochka \" 31 12 21 23 59 59 +03 00 High";

        //Act
        var result = _parser.ParseCommand(input);

        //Assert
        Assert.Equal(Command.InvalidInput, result.Command);
    }
    
    [Fact]
    public void Test_WhenPriorityIsInvalid()
    {
        //Arrange            
        string input = "add drochka \" ejednevnaya drochka \" 31.12.21 23.59.59 +03:00 zalupa";

        //Act
        var result = _parser.ParseCommand(input);

        //Assert
        Assert.Equal(Command.InvalidInput, result.Command);
    }
    
    [Fact]
    public void Test_DeleteByIndex()
    {
        // Arrange
        string addContent = "add xuy \"ejednevnaya drochka  add fasdh fsdhai\" 31.12.21 23.59.59 +03:00 Low";
        var addResult = _parser.ParseCommand(addContent);
        Assert.Equal(Command.Add, addResult.Command);
        string deleteContent = "delete 1";

        // Act
        var result = _parser.ParseCommand(deleteContent);

        // Assert
        Assert.Equal(Command.Delete, result.Command);
    }
}