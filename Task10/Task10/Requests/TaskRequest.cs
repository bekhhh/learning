using Task10.Models;

namespace Task10.Requests;

public class TaskRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime? DateTime { get; set; }
    public string? Description { get; set; }
    public Priority Priority { get; set; }

    public TaskRequest(string name = null, DateTime? dateTime = null, Priority priority = Priority.Medium, string? description = null,
        int id = 0)
    {
        Id = id;
        Name = name;
        DateTime = dateTime;
        Description = description;
        Priority = priority;
    }
}