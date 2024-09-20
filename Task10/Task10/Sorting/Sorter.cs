namespace Task10;

public class Sorter
{
    private TaskManager _taskManager;

    public Sorter(TaskManager taskManager)
    {
        _taskManager = taskManager;
    }

    public void SortByNameAsc()
    {
        _taskManager.Tasks.Sort((t1, t2) => string.Compare(t1.Name, t2.Name, StringComparison.Ordinal));
    }

    public void SortByNameDesc()
    {
        _taskManager.Tasks.Sort((t1, t2) => string.Compare(t2.Name, t1.Name, StringComparison.Ordinal));
    }

    public void SortByDateAsc()
    {
        _taskManager.Tasks.Sort((t1, t2) => DateTime.Compare(t1.DateTime, t2.DateTime));
    }

    public void SortByDateDesc()
    {
        _taskManager.Tasks.Sort((t1, t2) => DateTime.Compare(t2.DateTime, t1.DateTime));
    }

    public void SortByPriorityAsc()
    {
        _taskManager.Tasks.Sort((t1, t2) => t1.Priority.CompareTo(t2.Priority));
    }

    public void SortByPriorityDesc()
    {
        _taskManager.Tasks.Sort((t1, t2) => t2.Priority.CompareTo(t1.Priority));
    }

    public void SortByIdAsc()
    {
        _taskManager.Tasks.Sort((t1, t2) => t1.Id.CompareTo(t2.Id));
    }

    public void SortByIdDesc()
    {
        _taskManager.Tasks.Sort((t1, t2) => t2.Id.CompareTo(t1.Id));
    }
}