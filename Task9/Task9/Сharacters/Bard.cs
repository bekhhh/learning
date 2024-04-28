using Task9.Items;

namespace Task9.Сharacters
{
    public class Bard : CharacterProperty,IStartItems
    {
        public int Сharisma { get; set; } = 8; //наличие харизмы(может купить по скидке)
        public bool Mood { get; set; } = true; // если тру, то немного хилит        
        public string Lute { get; set;} //+ армор союзникам
        public override object[] PersonalItem => new object[] { Lute };
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
            Console.WriteLine($"Сharisma, Mood, Health, MovementSpeed, AttackSpeed, Dexterity, Armor ");
        }
        public override void PrintItems()
        {
            Console.WriteLine($"Lute, Boots, Cloak, HealingPotion");
        }
    }
}
