namespace Task10.Models;

public record Task(
    int Id,
    string Name,
    string? Description = null,
    DateTime? DateTime = null,
    Priority Priority = Priority.Medium);