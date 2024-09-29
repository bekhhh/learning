using Task10.Models;

namespace Task10;

public class TaskRequest
{
    public int Id { get; }
    public string Name { get; }
    public DateTime DateTime { get; }
    public string? Description { get; }
    public Priority Priority { get; }

    public TaskRequest(string name, DateTime dateTime, Priority priority = Priority.Medium, string? description = null,
        int id = 0)
    {
        Id = id;
        Name = name;
        DateTime = dateTime;
        Description = description;
        Priority = priority;
    }
}