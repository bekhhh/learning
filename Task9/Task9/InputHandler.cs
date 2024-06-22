using Newtonsoft.Json;
using System.Linq.Expressions;
using Task9.Сharacters;
using Task9.Сharacters.Ability;

namespace Task9
{
    public class InputHandler
    {
        public void HandlerInput()
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
            Console.WriteLine(string.Join(" ", characters.Keys));
            Console.WriteLine();
            Character? character = null;
            bool hasStarted = false;
            while (true)
            {
                try
                {
                    var input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Введена пустая строка");
                        continue;
                    }
                    var words = input.Split(' ')
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrEmpty(x))
                    .ToArray();
                    if (words[0] == "get")
                    {
                        if (!characters.TryGetValue(words[2], out character))
                        {
                            Console.WriteLine("Такого персонажа не существует");
                            continue;
                        }
                        if (words[1] == "items")
                        {
                            character.PrintItems();
                            continue;
                        }
                        else if (words[1] == "description")
                        {
                            character.PrintСharacteristic();
                            continue;
                        }
                    }
                    if (!hasStarted)
                    {
                        if (words[0] == "start")
                        {
                            if (characters.TryGetValue(words[1], out character))
                            {
                                Console.WriteLine($"You choose {words[1]} ");
                                character.PrintJson();
                                hasStarted = true;
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Введены неверные данные");
                        }
                    }
                    else
                    {
                        if (words[0] == "add" && words[1] == "ability")
                        {
                            if (!Enum.TryParse(words[5], out Element element))
                            {
                                Console.WriteLine("Введены неверные данные");
                                continue;
                            }
                            var ability = new Ability(words[2], words[3], int.Parse(words[4]), element);
                            character.Abilities.Add(ability);
                            Console.WriteLine($"Добавлена способность {ability.Name}");
                            continue;
                        }
                        if (words[0] == "show" && words[1] == "info")
                        {
                            character.PrintInfo();
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Введены неверные данные");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
