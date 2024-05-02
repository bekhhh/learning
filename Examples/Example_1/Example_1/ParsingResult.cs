using Example_1.TreeBuilding;
namespace Example_1
{
    public class ParsingResult
    {
        public Tree? Tree { get; init; }
        public bool IsError { get; init; }
        public string? ErrorMessage { get; init; }

        public static ParsingResult GetBaseFail() => new()
        {
            IsError = true,
            ErrorMessage = "Неверный формат строки",
        };
    }
}