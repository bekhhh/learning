using System.Globalization;
namespace Example_1.TreeBuilding
{
    public class TreeParser
    {
        public ParsingResult ParseTree(string input)
        {
            var words = input.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();

            return BuildTree(words);
        }

        private ParsingResult BuildTree(string[] words)
        {
            for (var index = words.Length - 1; index >= 0; index--)
            {
                var currentWord = words[index];

                Operation operation;
                if (currentWord == "+")
                {
                    operation = Operation.Plus;
                }
                else if (currentWord == "-")
                {
                    operation = Operation.Minus;
                }
                else
                {
                    continue;
                }

                var previousWordsCount = index;
                var leftPartParsingResult = BuildTree(words.Take(previousWordsCount).ToArray());
                if (leftPartParsingResult.IsError)
                {
                    return leftPartParsingResult;
                }

                var rightPartParsingResult = BuildTreeByHighPriorityOperation(words.Skip(previousWordsCount + 1).ToArray());
                if (rightPartParsingResult.IsError)
                {
                    return rightPartParsingResult;
                }

                return new ParsingResult
                {
                    Tree = new Tree(operation, leftPartParsingResult.Tree, rightPartParsingResult.Tree)
                };
            }

            return BuildTreeByHighPriorityOperation(words);
        }

        private ParsingResult BuildTreeByHighPriorityOperation(string[]? words)
        {
            //Проверка на пустой массив
            if (words == null || words.Length == 0)
            {
                return ParsingResult.GetBaseFail();
            }

            //Последнее слово должно быть числом
            if (!double.TryParse(words[^1], NumberStyles.Float, CultureInfo.InvariantCulture, out var number))
            {
                return ParsingResult.GetBaseFail();
            }

            //Если слово одно, то это просто число. Возвращаем результат сразу
            if (words.Length == 1)
            {
                return new ParsingResult
                {
                    Tree = new Tree(number)
                };
            }

            //Если слов несколько, то предпоследним словом должна быть операция
            var operationWord = words[^2];
            Operation operation;
            if (operationWord == "*")
            {
                operation = Operation.Multiply;
            }
            else if (operationWord == "/")
            {
                operation = Operation.Divide;
                if (number == 0)
                {
                    return new ParsingResult
                    {
                        IsError = true,
                        ErrorMessage = "Делить на ноль нельзя",
                    };
                }
            }
            else
            {
                return ParsingResult.GetBaseFail();
            }

            var leftPartWordsCount = words.Length - 2;
            var leftPartResult = BuildTreeByHighPriorityOperation(words.Take(leftPartWordsCount).ToArray());
            if (leftPartResult.IsError)
            {
                //Если ошибка в парсинге левой части, то возвращем эту же ошибку вверх.
                return leftPartResult;
            }

            var rightTree = new Tree(number);
            var leftTree = leftPartResult.Tree;

            return new ParsingResult
            {
                Tree = new Tree(operation, leftTree, rightTree)
            };
        }
    }
}