using Task9.Items;

namespace Task9.Сharacters
{
    public class Wizard : CharacterProperty, IStartItems
    {
        public int Mana { get; set; } = 5; //наличие маны
        public int MagicResistance { get; set; } = 5; //маг резист
        public string Staff { get; set; } // наличие посоха
        public override object[] PersonalItem => new object[] { Staff };
        public string Boots { get; set; }
        public string Cloak { get; set; }
        public string HealingPotion { get; set; }
        public override double Health { get; set; } = 10;
        public override int MovementSpeed { get; set; } = 5;
        public override int AttackSpeed { get; set; } = 5;
        public override int Dexterity { get; set; } = 5;
        public override double Armor { get; set; } = 10;

        public override void PrintСharacteristic()
        {
            Console.WriteLine($"Mana, MagicResistance, Health, MovementSpeed, AttackSpeed, Dexterity, Armor ");
        }
        public override void PrintItems()
        {
            Console.WriteLine($"Staff, Boots, Cloak, HealingPotion");
        }
    }
}