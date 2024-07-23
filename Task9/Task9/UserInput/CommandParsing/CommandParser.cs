using System.Text.RegularExpressions;
using System.Xml.Linq;
using Task9.Сharacters;
using Task9.Сharacters.Ability;

namespace Task9.UserInput.CommandParsing
{
    public class CommandParser
    {
        public Character? character;
        private bool hasStarted = false;
        private string[]? _words;
        private int _manaCost;
        private Element _element;
        private Ability? _newAbility;
        private readonly Dictionary<string, Character> _characters = new Dictionary<string, Character>
        {
            { nameof(Ranger), new Ranger() },
            { nameof(Cleric), new Cleric() },
            { nameof(Bard), new Bard() },
            { nameof(Druid), new Druid() },
            { nameof(Rogue), new Rogue() },
            { nameof(Wizard), new Wizard() },
            { nameof(Warrior), new Warrior() }
        };
        public CommandParsingResult Parse(string input)
        {           
            if (string.IsNullOrEmpty(input))
            {
                return new CommandParsingResult(Command.InvalidInput,
                "Не получилось распознать команду. Введите строку в нужном формате.");
            }
            _words = input.Split(' ')
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrEmpty(x))
                    .ToArray();

            switch (_words[0])
            {
                case "get":
                    return ParseGetItemsAndDescription(_words);
                case "start":
                    return ParseStart(_words);
                case "show":
                    return ParseShow(_words);
                case "add":
                    return ParseAddAbility(_words);
                default:
                    return new CommandParsingResult(Command.InvalidInput,
                    "Не удалось распознать команду (первое слово). Введите команду из инструкции.");
            }
        }
        private CommandParsingResult ParseGetItemsAndDescription(string[] input)
        {
            if (_words[0] == "get")
            {
                if (_words.Length != 3)
                {
                    return new CommandParsingResult(Command.InvalidInput,
                    "Команда get состоит из 3 слов, введите команду в нужном формате.");
                }
                if (_words[1] != "items" && _words[1] != "description")
                {
                    return new CommandParsingResult(Command.InvalidInput,
                    "Не получилось распознать команду get (введенное второе слово). Введите команду в нужном формате.");
                }
                if (!_characters.TryGetValue(_words[2], out character))
                {
                    return new CommandParsingResult(Command.InvalidInput,
                    "Персонажа (третье слово) не существует. Укажите в команде персонажа из начального списка.");
                }
            }
            return new CommandParsingResult(_words[1] == "items" ? Command.GetItems : Command.GetDescription, character: character);
        }

        private CommandParsingResult ParseStart(string[] input)
        {
            if (_words[0] == "start")
            {
                if (_words.Length != 2)
                {
                    return new CommandParsingResult(Command.InvalidInput,
                    "Команда start состоит из 2 слов, введите команду в нужном формате.");
                }
                if (!_characters.TryGetValue(_words[1], out character))
                {
                    return new CommandParsingResult(Command.InvalidInput,
                    "Персонажа (второе слово) не существует. Укажите в команде персонажа из начального списка.");
                }
                if (hasStarted)
                {
                    return new CommandParsingResult(Command.InvalidInput,
                    "Команду start можно использовать один раз за запуск. Введите другую команду.");
                }
                hasStarted = true;
            }
            return new CommandParsingResult(Command.Start, character: character);
        }

        private CommandParsingResult ParseShow(string[] input)
        {
            if (_words[0] == "show")
            {
                if (_words.Length != 2)
                {
                    return new CommandParsingResult(Command.InvalidInput,
                    "Команда show состоит из 2 слов, введите команду в нужном формате.");
                }
                if (_words[1] != "info")
                {
                    return new CommandParsingResult(Command.InvalidInput,
                    "Не удалось распознать команду info (второе слово)");
                }
            }
            return new CommandParsingResult(Command.ShowInfo, character: character);
        }

        private CommandParsingResult ParseAddAbility(string[] input)
        {
            if (input.Length != 6)
            {
                return new CommandParsingResult(Command.InvalidInput,
                    "Команда add состоит из 6 слов, введите команду в нужном формате.");
            }

            if (input[1] != "ability")
            {
                return new CommandParsingResult(Command.InvalidInput,
                    "Не удалось распознать команду ability (второе слово)");
            }

            if (!Regex.IsMatch(input[2], @"^[a-zA-Zа-яА-Я]+$"))
            {
                return new CommandParsingResult(Command.InvalidInput,
                    "Имя способности должно содержать только буквы латинского или кириллического алфавита. Выберите другое имя для способности.");
            }

            if (!Regex.IsMatch(input[3], @"^[a-zA-Zа-яА-Я]+$"))
            {
                return new CommandParsingResult(Command.InvalidInput,
                    "Описание способности должно содержать только буквы латинского или кириллического алфавита. Выберите другое описание для способности.");
            }

            if (!int.TryParse(input[4], out _manaCost))
            {
                return new CommandParsingResult(Command.InvalidInput,
                    "В команде add ability на 4 позиции должно быть число, указывающее стоимость в мане.");
            }

            if (!Enum.TryParse<Element>(input[5], out _element))
            {
                return new CommandParsingResult(Command.InvalidInput,
                    "В команде add ability на 5 позиции должно быть слово одной из стихии: Earth, Fire, Water, Air.");
            }

            _newAbility = new Ability(input[2], input[3], _manaCost, _element);
            return new CommandParsingResult(Command.AddAbility, ability: _newAbility, character: character);
        }
    }
}
