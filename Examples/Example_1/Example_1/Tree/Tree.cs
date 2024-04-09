namespace Example_1.Tree
{
    public class Tree
    {
        public Tree? Left { get; init; }
        public Tree? Right { get; init; }
        
        public double Number { get; init; }
        public Operation Operation { get; init; }

        public double GetResult()
        {
            if (Operation != Operation.None && (Left == null || Right == null))
            {
                throw new ArgumentException("Right or left tree is null when operation resolving");
            }
            
            switch (Operation)
            {
                case Operation.None: return Number;
                case Operation.Plus: return Left.GetResult() + Right.GetResult();
                case Operation.Minus: return Left.GetResult() - Right.GetResult();
                case Operation.Multiply: return Left.GetResult() * Right.GetResult();
                case Operation.Divide: return Left.GetResult() / Right.GetResult();
                default: throw new ArgumentOutOfRangeException();
            }
        }

        public static Tree GetSimple(double number) => new()
        {
            Number = number,
            Operation = Operation.None,
        };
    }
}