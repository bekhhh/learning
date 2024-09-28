namespace Task10.Models;

public record Task(
    int Id,
    string Name,
    DateTime DateTime,
    Priority Priority = Priority.Medium,
    string? Description = null);