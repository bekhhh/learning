namespace Task10.Models;

public class StorageData
{
    public int LastIndexId { get; set; } = 1;
    public List<Task> Tasks { get; set; } = new();
}