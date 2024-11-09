/*using Moq;
using Task10.Interfaces;
using Task10.Models;
using Xunit;
using Assert = NUnit.Framework.Assert;
using Task = Task10.Models.Task;

namespace SortingTests;

public class Tests
{
    private StorageData _storageData;
    private Mock<ICommandParser> _parser;
    private Mock<ITaskManager> _taskManager;

    public Tests()
    {
        _storageData = new StorageData();
        _parser = new Mock<ICommandParser>();
        _taskManager = new Mock<ITaskManager>();
    }

    [Fact]
    public void SortTasks_ByNameAscending()
    {
        // Arrange
        string input = "update 999 NewTask";
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
        Xunit.Assert.Equal("OldTask", sortedTasks[0].Name);
        Xunit.Assert.Equal("AldTask", sortedTasks[1].Name);
    }

    [Fact]
    public void SortTasks_ByDateTimeAscending()
    {
        // Arrange
        var now = DateTime.Now;
        var earlier = now.AddHours(-1);
        _storageData.Tasks.Add(new Task(1, "Task1", "Description1", now, Priority.Low));
        _storageData.Tasks.Add(new Task(2, "Task2", "Description2", earlier, Priority.High));
        string input = "sort datetime asc";
        var result = _parser.ParseCommand(input);

        // Act
        _taskManager.SortTasks(result.SortRequest);
        var sortedTasks = _storageData.Tasks.OrderBy(t => t.DateTime).ToList();

        // Assert
        Xunit.Assert.Equal("Task2", sortedTasks[0].Name); 
        Xunit.Assert.Equal("Task1", sortedTasks[1].Name); 
    }

    [Fact]
    public void SortTasks_ByDateTimeDescending()
    {
        // Arrange
        var now = DateTime.Now;
        var earlier = now.AddHours(-1);
        _storageData.Tasks.Add(new Task(1, "Task1", "Description1", now, Priority.Low));
        _storageData.Tasks.Add(new Task(2, "Task2", "Description2", earlier, Priority.High));
        string input = "sort datetime desc";
        var result = _parser.ParseCommand(input);

        // Act
        _taskManager.SortTasks(result.SortRequest);
        var sortedTasks = _storageData.Tasks.OrderByDescending(t => t.DateTime).ToList();

        // Assert
        Xunit.Assert.Equal("Task1", sortedTasks[0].Name); 
        Xunit.Assert.Equal("Task2", sortedTasks[1].Name); 
    }

    [Fact]
    public void SortTasks_ByPriorityAscending()
    {
        // Arrange
        _storageData.Tasks.Add(new Task(1, "Task1", "Description1", DateTime.Now, Priority.Low));
        _storageData.Tasks.Add(new Task10.Models.Task(2, "Task2", "Description2", DateTime.UtcNow, Priority.High));
        string input = "sort priority asc";
        var result = _parser.ParseCommand(input);

        // Act
        _taskManager.SortTasks(result.SortRequest);
        var sortedTasks = _storageData.Tasks.OrderBy(t => t.Priority).ToList();

        // Assert
        Xunit.Assert.Equal(Priority.Low, sortedTasks[0].Priority);
        Xunit.Assert.Equal(Priority.High, sortedTasks[1].Priority);
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
        Xunit.Assert.Equal(Priority.Low, sortedTasks[0].Priority);
        Xunit.Assert.Equal(Priority.High, sortedTasks[1].Priority);
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
        Xunit.Assert.Equal(1, sortedTasks[0].Id); 
        Xunit.Assert.Equal(2, sortedTasks[1].Id); 
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
        Xunit.Assert.Equal(2, sortedTasks[0].Id); 
        Xunit.Assert.Equal(1, sortedTasks[1].Id); 
    }
}*/
