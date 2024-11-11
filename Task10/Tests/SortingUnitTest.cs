using System.Data.Common;
using Moq;
using Task10;
using Task10.CommandParsing;
using Task10.Interfaces;
using Task10.Models;
using Task10.Requests;
using Xunit;
using Assert = Xunit.Assert;
using Task = Task10.Models.Task;

namespace ParsingResultTest;

public class SortingUnitTest
{
    private readonly Mock<ITaskRepository> _mockTaskRepository;
    private readonly TaskManager _taskManager;
    private readonly StorageData _storageData;

    public SortingUnitTest()
    {
        _mockTaskRepository = new Mock<ITaskRepository>();
        _taskManager = new TaskManager(_mockTaskRepository.Object);
        _storageData = new StorageData { Tasks = new List<Task>() };
    }
    
    [Fact]
    public void SortIdInAsc()
    {
        //Arrange
        _storageData.Tasks.Add(new Task(1, "Task1", "First Task", DateTime.Now, Priority.Low));
        _storageData.Tasks.Add(new Task(2, "Task2", "Second Task", DateTime.UtcNow, Priority.High));
        _mockTaskRepository.Setup(r => r.LoadTasks()).Returns(_storageData);
        var sortRequest = new SortRequest("id", true);
        
        //Act
        var sortedData = _taskManager.SortTasks(sortRequest);

        //Assert
        Assert.Equal(1, sortedData.Tasks[0].Id);
        Assert.Equal(2, sortedData.Tasks[1].Id);
    }
    
    [Fact]
    public void SortIdInDesc()
    {
        //Arrange
        _storageData.Tasks.Add(new Task(1, "Task1", "First Task", DateTime.Now, Priority.Low));
        _storageData.Tasks.Add(new Task(2, "Task2", "Second Task", DateTime.UtcNow, Priority.High));
        _mockTaskRepository.Setup(r => r.LoadTasks()).Returns(_storageData);
        var sortRequest = new SortRequest("id", false);
        
        //Act
        var sortedData = _taskManager.SortTasks(sortRequest);

        //Assert
        Assert.Equal(1, sortedData.Tasks[1].Id);
        Assert.Equal(2, sortedData.Tasks[0].Id);
    }
    
    [Fact]
    public void SortNameInAsc()
    {
        //Arrange
        _storageData.Tasks.Add(new Task(1, "Task1", "First Task", DateTime.Now, Priority.Low));
        _storageData.Tasks.Add(new Task(2, "Task2", "Second Task", DateTime.UtcNow, Priority.High));
        _mockTaskRepository.Setup(r => r.LoadTasks()).Returns(_storageData);
        var sortRequest = new SortRequest("name", true);
        
        //Act
        var sortedData = _taskManager.SortTasks(sortRequest);

        //Assert
        Assert.Equal("Task1", sortedData.Tasks[0].Name);
        Assert.Equal("Task2", sortedData.Tasks[1].Name);
    }
    
    [Fact]
    public void SortNameInDesc()
    {
        //Arrange
        _storageData.Tasks.Add(new Task(1, "Task1", "First Task", DateTime.Now, Priority.Low));
        _storageData.Tasks.Add(new Task(2, "Task2", "Second Task", DateTime.UtcNow, Priority.High));
        _mockTaskRepository.Setup(r => r.LoadTasks()).Returns(_storageData);
        var sortRequest = new SortRequest("name", false);
        
        //Act
        var sortedData = _taskManager.SortTasks(sortRequest);

        //Assert
        Assert.Equal("Task1", sortedData.Tasks[1].Name);
        Assert.Equal("Task2", sortedData.Tasks[0].Name);
    }
    
    [Fact]
    public void SortPriorityInAsc()
    {
        //Arrange
        _storageData.Tasks.Add(new Task(1, "Task1", "First Task", DateTime.Now, Priority.Low));
        _storageData.Tasks.Add(new Task(2, "Task2", "Second Task", DateTime.UtcNow, Priority.High));
        _mockTaskRepository.Setup(r => r.LoadTasks()).Returns(_storageData);
        var sortRequest = new SortRequest("priority", true);
        
        //Act
        var sortedData = _taskManager.SortTasks(sortRequest);

        //Assert
        Assert.Equal(Priority.High, sortedData.Tasks[0].Priority);
        Assert.Equal(Priority.Low, sortedData.Tasks[1].Priority);
    }
    
    [Fact]
    public void SortPriorityInDesc()
    {
        //Arrange
        _storageData.Tasks.Add(new Task(1, "Task1", "First Task", DateTime.Now, Priority.Low));
        _storageData.Tasks.Add(new Task(2, "Task2", "Second Task", DateTime.UtcNow, Priority.High));
        _mockTaskRepository.Setup(r => r.LoadTasks()).Returns(_storageData);
        var sortRequest = new SortRequest("priority", false);
        
        //Act
        var sortedData = _taskManager.SortTasks(sortRequest);

        //Assert
        Assert.Equal(Priority.Low, sortedData.Tasks[1].Priority);
        Assert.Equal(Priority.High, sortedData.Tasks[0].Priority);
    }
    
    [Fact]
    public void SortDatetimeInAsc()
    {
        //Arrange
        DateTime data1 = new DateTime(2015, 7, 20, 18, 30, 25);
        DateTime data2 = new DateTime(2016, 7, 20, 18, 30, 25);
        _storageData.Tasks.Add(new Task(1, "Task1", "First Task", data1, Priority.Low));
        _storageData.Tasks.Add(new Task(2, "Task2", "Second Task", data2, Priority.High));
        _mockTaskRepository.Setup(r => r.LoadTasks()).Returns(_storageData);
        var sortRequest = new SortRequest("datetime", true);
        
        //Act
        var sortedData = _taskManager.SortTasks(sortRequest);

        //Assert
        Assert.Equal(data2, sortedData.Tasks[1].DateTime);
        Assert.Equal(data1, sortedData.Tasks[0].DateTime);
    }
    
    [Fact]
    public void SortDatetimeDesc()
    {
        //Arrange
        DateTime data1 = new DateTime(2015, 7, 20, 18, 30, 25);
        DateTime data2 = new DateTime(2016, 7, 20, 18, 30, 25);
        _storageData.Tasks.Add(new Task(1, "Task1", "First Task", data1, Priority.Low));
        _storageData.Tasks.Add(new Task(2, "Task2", "Second Task", data2, Priority.High));
        _mockTaskRepository.Setup(r => r.LoadTasks()).Returns(_storageData);
        var sortRequest = new SortRequest("datetime", false);
        
        //Act
        var sortedData = _taskManager.SortTasks(sortRequest);

        //Assert
        Assert.Equal(data1, sortedData.Tasks[1].DateTime);
        Assert.Equal(data2, sortedData.Tasks[0].DateTime);
    }
}