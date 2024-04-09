using System.Globalization;
namespace Example_1.Tree
{
    public class TreeParser
    {
        public ParsingResult ParseTree(string input)
        {
            var words = input.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();

            return BuildTreeByHighAndLowPriorityOperation(words);
        }

        private ParsingResult BuildTreeByHighAndLowPriorityOperation(string[] words)
        {
            for (var index = 0; index < words.Length; index++)
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
                var leftPartParsingResult = BuildTreeByHighPriorityOperation(words.Take(previousWordsCount).ToArray());
                if (leftPartParsingResult.IsError)
                {
                    return leftPartParsingResult;
                }

                var rightPartParsingResult = BuildTreeByHighAndLowPriorityOperation(words.Skip(previousWordsCount + 1).ToArray());
                if (rightPartParsingResult.IsError)
                {
                    return rightPartParsingResult;
                }

                return new ParsingResult
                {
                    Tree = new Tree
                    {
                        Left = leftPartParsingResult.Tree,
                        Right = rightPartParsingResult.Tree,
                        Operation = operation,
                    }
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

            //Первое слово должно быть числом
            if (!double.TryParse(words[0], NumberStyles.Float, CultureInfo.InvariantCulture, out var number))
            {
                return ParsingResult.GetBaseFail();
            }

            //Если слово одно, то это просто число. Возвращаем результат сразу
            if (words.Length == 1)
            {
                return new ParsingResult
                {
                    Tree = Tree.GetSimple(number)
                };
            }

            //Если слов несколько, то первым должно быть число, а вторым операция
            var operationWord = words[1];
            Operation operation;
            if (operationWord == "*")
            {
                operation = Operation.Multiply;
            }
            else if (operationWord == "/")
            {
                operation = Operation.Divide;
            }
            else
            {
                return ParsingResult.GetBaseFail();
            }

            var rightPartParsingResult = BuildTreeByHighPriorityOperation(words.Skip(2).ToArray());
            if (rightPartParsingResult.IsError)
            {
                //Если ошибка в парсинге правой части, то возвращем эту же ошибку вверх.
                return rightPartParsingResult;
            }

            var leftTree = Tree.GetSimple(number);
            var rightTree = rightPartParsingResult.Tree;

            return new ParsingResult
            {
                Tree = new Tree
                {
                    Left = leftTree,
                    Right = rightTree,
                    Operation = operation,
                }
            };
        }
    }
}