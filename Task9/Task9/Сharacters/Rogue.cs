using Task9.Items;

namespace Task9.Сharacters
{
    public class Rogue : CharacterProperty,IStartItems
    {
        public bool NightVision { get; set; } = false; //видит дадьше, если ночь
        public bool Invisibility { get; set; } = false; //скилл невидимость
        public string Dagger { get; set; } //наличие клинка + отравление
        public override object[] PersonalItem => new object[] { Dagger };
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
            Console.WriteLine($"NightVision, Invisibility, Health, MovementSpeed, AttackSpeed, Dexterity, Armor ");
        }
        public override void PrintItems()
        {
            Console.WriteLine($"Dagger, Boots, Cloak, HealingPotion");
        }
    }
}
