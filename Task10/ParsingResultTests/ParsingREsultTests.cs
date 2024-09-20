using Task10;
using Task10.CommandParsing;
using Task10.FileManager;
using Xunit;
using Assert = Xunit.Assert;
using Task = System.Threading.Tasks.Task;

namespace ParsingResultTest;

public class ParsingResultTest
{
    private CommandParser _parser;
    private TaskManager _taskManager;
    private FileWriter _fileWriter;
    private ConsolePrinter _consolePrinter;

    public ParsingResultTest()
    {
        _taskManager = new TaskManager();
        _fileWriter = new FileWriter(_taskManager); 
        _consolePrinter = new ConsolePrinter();
        _parser = new CommandParser(_taskManager, _fileWriter, _consolePrinter); 
        _taskManager.Tasks.Add(new Task10.Task(1, "OldTask", DateTime.Now, PriorityType.Medium, "Old Description"));
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
        string addContent = "add xuy \"ejednevnaya drochka bla bla bla\" 31.12.21 23.59.59 +03:00 Low";
        var addResult = _parser.ParseCommand(addContent);
        Assert.Equal(Command.Add, addResult.Command);
        _taskManager.Tasks.Add(addResult.Task);
        
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
        string input = "update 1 NewTask \"New Description\" 21.09.23 10.30.00 +03:00 Low";

        // Act
        var result = _parser.ParseCommand(input);

        // Assert
        Assert.Equal(Command.Update, result.Command);
        Assert.Equal("NewTask", result.Task.Name);
        Assert.Equal("New Description", result.Task.Description);
        Assert.Equal(PriorityType.Low, result.Task.Priority);
    }
    
    [Fact]
    public void Test_UpdateTask_TaskNotFound()
    {
        // Arrange
        string input = "update 999 NewTask";

        // Act
        var result = _parser.ParseCommand(input);

        // Assert
        Assert.Equal(Command.InvalidInput, result.Command);
        Assert.Equal("Задача с номером 999 не найдена.", result.Message);
    }
}