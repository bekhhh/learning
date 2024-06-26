﻿using Task9;
using Task9.Сharacters;

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
            while (true)
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
                if (words.Length != 3)
                {
                    Console.WriteLine("Введены неверные данные");
                    continue;
                }
                if (words[0] != "get")
                {
                    Console.WriteLine("Введены неверные данные");
                    continue;
                }
                if (!characters.TryGetValue(words[2], out var character))
                {
                    Console.WriteLine("Такого персонажа не существует");
                    continue;
                }
                if (words[1] == "items")
                {
                    character.PrintItems();
                }
                else if (words[1] == "description")
                {
                    character.PrintСharacteristic();
                }
            }
        }
    }
}
