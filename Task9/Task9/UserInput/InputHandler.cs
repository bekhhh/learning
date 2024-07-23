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
                    Character? character = result.Character; 

                    switch (result.Command)
                    {
                        case Command.InvalidInput:
                            Console.WriteLine(result.Message);
                            continue;
                        case Command.GetItems:
                            character.PrintItems(); 
                            continue;
                        case Command.GetDescription:
                            character.PrintСharacteristic(); 
                            continue;
                        case Command.Start:
                            character.PrintJson(); 
                            Console.WriteLine(InputInstructions.AfterStartRules);
                            continue;
                        case Command.ShowInfo:
                            character.PrintJson(); 
                            continue;
                        case Command.AddAbility:                            
                                character.Abilities.Add(result.Ability);
                                Console.WriteLine($"Способность {result.Ability.Name} добавлена.");                            
                            continue;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
