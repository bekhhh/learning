using Task9.Items;

namespace Task9.Сharacters
{
    public class Ranger : CharacterProperty,IStartItems
    {
        public enum DrawLength // Длина растяжки (натяжения)
        {
            Weak,
            Normal,
            Strong
        }
        public DrawLength Bow { get; set; }
        public override object[] PersonalItem => new object[] { Bow };
        public bool isHidden { get; set; } = false; //если да, то + урон
        public bool RangeAttack { get; set; } = false; //наличие дальной атаки
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
            Console.WriteLine($"isHidden, RangeAttack, Health, MovementSpeed, AttackSpeed, Dexterity, Armor ");
        }
        public override void PrintItems()
        {
            Console.WriteLine($"Bow, Boots, Cloak, HealingPotion");
        }
    }
}
