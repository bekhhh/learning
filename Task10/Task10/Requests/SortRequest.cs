namespace Task10.Requests;

public class SortRequest
{
    public string Field { get; } 
    public bool Ascending { get; }

    public SortRequest(string field, bool ascending = true)
    {
        Field = field;
        Ascending = ascending;
    }
}