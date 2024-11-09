using Task10.Models;
using Task = Task10.Models.Task;

namespace Task10.Interfaces;

public interface ITaskRepository
{
    void SaveTasks(StorageData storageData);
    StorageData LoadTasks();
}