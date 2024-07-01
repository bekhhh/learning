using System.Text.RegularExpressions;
using Task9.Сharacters;
using Task9.Сharacters.Ability;

namespace Task9.UserInput.CommandParsing
{
    public class CommandParser
    {
        public CommandParsingResult Parse(string input)
        {
            var characters = new Dictionary<string, Character>
            {
               { nameof(Ranger), new Ranger() },
               { nameof(Cleric), new Cleric() },
               { nameof(Bard), new Bard() },
               { nameof(Druid), new Druid() },
               { nameof(Rogue), new Rogue() },
               { nameof(Wizard), new Wizard() },
               { nameof(Warrior), new Warrior() }
            };
            Character? character = null;
            bool hasStarted = false;
            if (string.IsNullOrEmpty(input))
            {
                return new CommandParsingResult(Command.InvalidInput,
                "Не получилось распознать команду. Введите строку в нужном формате.");
            }
            var words = input.Split(' ')
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrEmpty(x))
                    .ToArray();
            if (words[0] == "get")
            {
                if (words.Length != 3)
                {
                    return new CommandParsingResult(Command.InvalidInput,
                    "Команда get состоит из 3 слов, введите команду в нужном формате.");
                }
                if (words[1] != "items" && words[1] != "description")
                {
                    return new CommandParsingResult(Command.InvalidInput,
                    "Не получилось распознать команду get (введенное второе слово). Введите команду в нужном формате.");
                }
                if (!characters.TryGetValue(words[2], out character))
                {
                    return new CommandParsingResult(Command.InvalidInput,
                    "Персонажа (третье слово) не существует. Укажите в команде персонажа из начального списка.");
                }
                if (words[1] == "items")
                {
                    return new CommandParsingResult(Command.GetItems);
                }
                else if (words[1] == "description")
                {
                    return new CommandParsingResult(Command.GetDescription);
                }
            }
            else if (words[0] == "start")
            {
                if (words.Length != 2)
                {
                    return new CommandParsingResult(Command.InvalidInput,
                    "Команда start состоит из 2 слов, введите команду в нужном формате.");
                }
                if (!characters.TryGetValue(words[1], out character))
                {
                    return new CommandParsingResult(Command.InvalidInput,
                    "Персонажа (второе слово) не существует. Укажите в команде персонажа из начального списка.");
                }
                if (hasStarted)
                {
                    return new CommandParsingResult(Command.InvalidInput,
                    "Команду start можно использовать один раз за запуск. Введите другую команду.");
                }
                return new CommandParsingResult(Command.Start);
            }
            else if (words[0] == "show")
            {
                if (words.Length != 2)
                {
                    return new CommandParsingResult(Command.InvalidInput,
                    "Команда show состоит из 2 слов, введите команду в нужном формате.");
                }
                if (words[1] != "info")
                {
                    return new CommandParsingResult(Command.InvalidInput,
                    "Не удалось распознать команду info (второе слово)");
                }
                return new CommandParsingResult(Command.ShowInfo);
            }
            else if (words[0] == "add")
            {
                if (words.Length != 5)
                {
                    return new CommandParsingResult(Command.InvalidInput,
                    "Команда add состоит из 5 слов, введите команду в нужном формате.");
                }
                if (words[1] != "ability")
                {
                    return new CommandParsingResult(Command.InvalidInput,
                    "Не удалось распознать команду ability (второе слово)");
                }
                if (!Regex.IsMatch(words[2], @"^[a-zA-Zа-яА-Я]+$"))
                {
                    return new CommandParsingResult(Command.InvalidInput,
                    "Имя способности должно содержать только буквы латинского или кириллического алфавита. Выберете другое имя для способности");
                }
                if (!int.TryParse(words[3], out var manaCost))
                {
                    return new CommandParsingResult(Command.InvalidInput,
                    "В команде add ability на 4 позиции должно быть число, указывающее стоимость в мане.");
                }
                if (!Enum.TryParse<Element>(words[4], out var element))
                {
                    return new CommandParsingResult(Command.InvalidInput,
                    "В команде add ability на 5 позиции должно быть слово одной из стихии: Earth, Fire, Water, Air.");
                }
                var ability = new Ability(words[2], words[3], manaCost, element);
                return new CommandParsingResult(Command.AddAbility, ability: ability);
            }
            return new CommandParsingResult(Command.InvalidInput,
            "Не удалось распознать команду (первое слово). Введите команду из инструкции.");
        }
    }
}
