using System.Security.Cryptography;

namespace Task10.Сharacters
{
    public class Cleric : Сharacteristic
    {
        public int Heal { get; set; }
        public string Jump { get; set; }
        public string FirstAidKit { get; set; }
        public override StartItems[] CharacterStartItems => new StartItems[]
        {
         StartItems.Boots,
         StartItems.Cloak,
         StartItems.HealingPotion
        };
        public override double Health { get; set; }
        public override int MovementSpeed { get; set; }
        public override int AttackSpeed { get; set; }
        public override int Dexterity { get; set; }
        public override double Armor { get; set; }

        public override void PrintСharacteristic()
        {
            Console.WriteLine($"Heal, Jump, Health, MovementSpeed, AttackSpeed, Dexterity, Armor ");
        }
        public override void PrintItems()
        {
            Console.WriteLine($"FirstAidKit, Boots, Cloak, HealingPotion");
        }
    }
}
