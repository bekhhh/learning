namespace Example_1
{
    public class ParsingResult
    {
        public Tree.Tree? Tree { get; init; }
        public bool IsError { get; init; }
        public string? ErrorMessage { get; init; }
    }
}