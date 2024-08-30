namespace Task10;

public class Task
{
    public int Id { get; }
    public string Name { get; }
    public DateTime DateTime { get; }
    public string? Description { get; }
    public PriorityType Priority { get; }

    public Task(int id, string name, DateTime dateTime, PriorityType priority = PriorityType.Medium, string? description = null)
    {
        Id = id;
        Name = name;
        DateTime = dateTime;
        Description = description;
        Priority = priority;
    }
}