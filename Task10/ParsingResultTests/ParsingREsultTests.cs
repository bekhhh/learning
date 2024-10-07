using Task10;
using Task10.CommandParsing;
using Task10.FileManager;
using Task10.Interfaces;
using Task10.Models;
using Task10.Requests;
using Task10.UserInteraction;
using Xunit;
using Assert = Xunit.Assert;
using Task = Task10.Models.Task;

namespace ParsingResultTest;

public class ParsingResultTest
{
    private readonly ITaskRepository _tasksRepository;
    private readonly IConsolePrinter _consolePrinter;
    private readonly StorageData _storageData;
    private CommandParser _parser;
    private readonly TaskManager _taskManager;
    
    public ParsingResultTest()
    {
        _consolePrinter = new ConsolePrinter();
        _tasksRepository = new TasksRepository(_consolePrinter);
        _storageData = new StorageData();
        _taskManager = new TaskManager(_tasksRepository, _consolePrinter, _storageData);
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
    
    [Fact]
    public void SortTasks_ByNameAscending()
    {
        // Arrange
        _storageData.Tasks.Add(new Task(1, "OldTask", "Old Description", DateTime.Now, Priority.Low));
        _storageData.Tasks.Add(new Task(2, "AldTask", "Ald Description", DateTime.UtcNow, Priority.High));
        string input = "sort name asc";
        var result = _parser.ParseCommand(input);

        // Act
        _taskManager.SortTasks(result.SortRequest);
        var sortedTasks = _storageData.Tasks.OrderBy(t => t.Name).ToList();

        // Assert
        Assert.Equal("AldTask", sortedTasks[0].Name);
        Assert.Equal("OldTask", sortedTasks[1].Name);
    }

    [Fact]
    public void SortTasks_ByNameDescending()
    {
        // Arrange
        _storageData.Tasks.Add(new Task(1, "OldTask", "Old Description", DateTime.Now, Priority.Low));
        _storageData.Tasks.Add(new Task(2, "AldTask", "Ald Description", DateTime.UtcNow, Priority.High));
        string input = "sort name desc";
        var result = _parser.ParseCommand(input);

        // Act
        _taskManager.SortTasks(result.SortRequest);
        var sortedTasks = _storageData.Tasks.OrderByDescending(t => t.Name).ToList();

        // Assert
        Assert.Equal("OldTask", sortedTasks[0].Name);
        Assert.Equal("AldTask", sortedTasks[1].Name);
    }

    [Fact]
    public void SortTasks_ByDateTimeAscending()
    {
        // Arrange
        var now = DateTime.Now;
        var earlier = now.AddHours(-1);
        _storageData.Tasks.Add(new Task(1, "Task1", "Description1", now, Priority.Medium));
        _storageData.Tasks.Add(new Task(2, "Task2", "Description2", earlier, Priority.High));
        string input = "sort datetime asc";
        var result = _parser.ParseCommand(input);

        // Act
        _taskManager.SortTasks(result.SortRequest);
        var sortedTasks = _storageData.Tasks.OrderBy(t => t.DateTime).ToList();

        // Assert
        Assert.Equal("Task2", sortedTasks[0].Name); 
        Assert.Equal("Task1", sortedTasks[1].Name); 
    }

    [Fact]
    public void SortTasks_ByDateTimeDescending()
    {
        // Arrange
        var now = DateTime.Now;
        var earlier = now.AddHours(-1);
        _storageData.Tasks.Add(new Task(1, "Task1", "Description1", now, Priority.Medium));
        _storageData.Tasks.Add(new Task(2, "Task2", "Description2", earlier, Priority.High));
        string input = "sort datetime desc";
        var result = _parser.ParseCommand(input);

        // Act
        _taskManager.SortTasks(result.SortRequest);
        var sortedTasks = _storageData.Tasks.OrderByDescending(t => t.DateTime).ToList();

        // Assert
        Assert.Equal("Task1", sortedTasks[0].Name); 
        Assert.Equal("Task2", sortedTasks[1].Name); 
    }

    [Fact]
    public void SortTasks_ByPriorityAscending()
    {
        // Arrange
        _storageData.Tasks.Add(new Task(1, "Task1", "Description1", DateTime.Now, Priority.Low));
        _storageData.Tasks.Add(new Task(2, "Task2", "Description2", DateTime.UtcNow, Priority.High));
        string input = "sort priority asc";
        var result = _parser.ParseCommand(input);

        // Act
        _taskManager.SortTasks(result.SortRequest);
        var sortedTasks = _storageData.Tasks.OrderBy(t => t.Priority).ToList();

        // Assert
        Assert.Equal(Priority.Low, sortedTasks[0].Priority);
        Assert.Equal(Priority.High, sortedTasks[1].Priority);
    }

    [Fact]
    public void SortTasks_ByPriorityDescending()
    {
        // Arrange
        _storageData.Tasks.Add(new Task(1, "Task1", "Description1", DateTime.Now, Priority.Low));
        _storageData.Tasks.Add(new Task(2, "Task2", "Description2", DateTime.UtcNow, Priority.High));
        string input = "sort priority desc";
        var result = _parser.ParseCommand(input);

        // Act
        _taskManager.SortTasks(result.SortRequest);
        var sortedTasks = _storageData.Tasks.OrderByDescending(t => t.Priority).ToList();

        // Assert
        Assert.Equal(Priority.Low, sortedTasks[0].Priority);
        Assert.Equal(Priority.High, sortedTasks[1].Priority);
    }

    [Fact]
    public void SortTasks_ByIdAscending()
    {
        // Arrange
        _storageData.Tasks.Add(new Task(2, "Task2", "Description2", DateTime.Now, Priority.Low));
        _storageData.Tasks.Add(new Task(1, "Task1", "Description1", DateTime.UtcNow, Priority.High));
        string input = "sort id asc";
        var result = _parser.ParseCommand(input);

        // Act
        _taskManager.SortTasks(result.SortRequest);
        var sortedTasks = _storageData.Tasks.OrderBy(t => t.Id).ToList();

        // Assert
        Assert.Equal(1, sortedTasks[0].Id); 
        Assert.Equal(2, sortedTasks[1].Id); 
    }

    [Fact]
    public void SortTasks_ByIdDescending()
    {
        // Arrange
        _storageData.Tasks.Add(new Task(2, "Task2", "Description2", DateTime.Now, Priority.Low));
        _storageData.Tasks.Add(new Task(1, "Task1", "Description1", DateTime.UtcNow, Priority.High));
        string input = "sort id desc";
        var result = _parser.ParseCommand(input);

        // Act
        _taskManager.SortTasks(result.SortRequest);
        var sortedTasks = _storageData.Tasks.OrderByDescending(t => t.Id).ToList();

        // Assert
        Assert.Equal(2, sortedTasks[0].Id); 
        Assert.Equal(1, sortedTasks[1].Id); 
    }
}
    
    
