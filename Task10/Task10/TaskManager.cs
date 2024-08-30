using Newtonsoft.Json;

namespace Task10;

public class TaskManager
{
    public List<Task> Tasks { get; } = new List<Task>();
    
    public void PrintJson()
    {           
        Console.WriteLine(JsonConvert.SerializeObject(this, Formatting.Indented));
    }
}