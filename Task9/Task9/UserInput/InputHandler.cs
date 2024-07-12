using System.Threading.Channels;
using Task9.UserInput.CommandParsing;
using Task9.Сharacters;

namespace Task9.UserInput
{
    public class InputHandler
    {        
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
                        case Command.InvalidInput:
                            Console.WriteLine(result.Message);
                            continue;
                        case Command.GetItems:
                            Parser.character.PrintItems();
                            continue;
                        case Command.GetDescription:
                            Parser.character.PrintСharacteristic();
                            continue;
                        case Command.Start:
                            Parser.character.PrintJson(); 
                            Console.WriteLine(InputInstructions.AfterStartRules);
                            continue;
                        case Command.ShowInfo:
                            Parser.character.PrintJson();
                            continue;
                        case Command.AddAbility:
                            Parser.character.Abilities.Add(result.Ability);
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
