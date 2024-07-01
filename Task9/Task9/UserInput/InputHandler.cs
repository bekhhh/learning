using Newtonsoft.Json;
using System.Linq.Expressions;
using Task9.UserInput.CommandParsing;
using Task9.Сharacters;
using Task9.Сharacters.Ability;

namespace Task9.UserInput
{
    public class InputHandler
    {
        public Character Character { get; set; } = null;
        public CommandParser Parser { get; set; }
        public InputHandler()
        {
            Parser = new CommandParser();
        }
        public void HandlerInput()
        {
            Console.WriteLine(CharactersList.PrintCharacters);
            Console.WriteLine();
            Console.WriteLine(InputInstructions.StartRules);
            Console.WriteLine();
            while (true)
            {
                try
                {
                    var input = Console.ReadLine();                    
                    var result = Parser.Parse(input);
                    switch (result.Command) 
                    {
                        case Command.InvalidInput: Console.WriteLine(result.Message); continue;
                        case Command.GetItems: Character.PrintItems(); continue;
                        case Command.GetDescription: Character.PrintСharacteristic(); continue;
                        case Command.Start: Character.PrintJson(); Console.WriteLine(InputInstructions.AfterStartRules); continue;
                        case Command.AddAbility:
                            Character.Abilities.Add(result.Ability);
                            Console.WriteLine($"Способность {result.Ability.Name} добавлена.");
                            continue;
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
