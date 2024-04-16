using Task9.Сharacters;

namespace Task9
{
    public class InputHandler
    {       
        public void HandlerInput()
        {
            var ranger = new Ranger();
            var cleric = new Cleric();
            var bard = new Bard();
            var druid = new Druid();
            var rogue = new Rogue();
            var wizard = new Wizard();
            var warrior = new Warrior();

            Console.WriteLine($"Ranger Cleric Bard Druid Rogue Warrior Wizard");
            Console.WriteLine();
            while (true)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Введена пустая строка");
                    continue;
                }
                var words = input.Split('.', '?', '!', ' ', ';', ':', ',')
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrEmpty(x))
                .ToArray();
                if (words[0] == "get" && words[1] == "description")
                {
                    switch (words[2])
                    {
                        case "Ranger":
                            ranger.PrintСharacteristic();
                            break;
                        case "Cleric":
                            cleric.PrintСharacteristic();
                            break;
                        case "Bard":
                            bard.PrintСharacteristic();
                            break;
                        case "Druid":
                            druid.PrintСharacteristic();
                            break;
                        case "Rogue":
                            rogue.PrintСharacteristic();
                            break;
                        case "Wizard":
                            wizard.PrintСharacteristic();
                            break;
                        case "Warrior":
                            warrior.PrintСharacteristic();
                            break;
                    }
                }
                else if (words[0] == "get" && words[1] == "items")
                {
                    switch (words[2])
                    {
                        case "Ranger":
                            ranger.PrintItems();
                            break;
                        case "Cleric":
                            cleric.PrintItems();
                            break;
                        case "Bard":
                            bard.PrintItems();
                            break;
                        case "Druid":
                            druid.PrintItems();
                            break;
                        case "Rogue":
                            rogue.PrintItems();
                            break;
                        case "Wizard":
                            wizard.PrintItems();
                            break;
                        case "Warrior":
                            warrior.PrintItems();
                            break;
                    }
                }
                else 
                {
                    Console.WriteLine("Введены неверные данные");
                    continue;
                }
            }           
        }
    }
}