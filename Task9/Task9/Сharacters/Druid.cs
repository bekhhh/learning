using Task9.Items;

namespace Task9.Сharacters
{
    public class Druid : CharacterProperty,IStartItems
    {
        public bool ForestArmor { get; set; } = false;//если в лесу + армор
        public int Vision { get; set; } = 10; //хороший слух
        public string Summoner { get; set; } //имеет саммонера
        public override object[] PersonalItem => new object[] { Summoner };
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
            Console.WriteLine($"ForestArmor, Hearing, Health, MovementSpeed, AttackSpeed, Dexterity, Armor ");
        }
        public override void PrintItems()
        {
            Console.WriteLine($"Summoner, Boots, Cloak, HealingPotion");
        }
    }
}
