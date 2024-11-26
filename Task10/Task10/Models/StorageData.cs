namespace Task10.Models;

public class StorageData
{
    public int LastIndexId { get; set; }
    public List<Task> Tasks { get; set; } = new();
}