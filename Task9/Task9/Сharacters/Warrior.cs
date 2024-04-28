using Task9.Items;

namespace Task9.Сharacters
{
    public class Warrior : CharacterProperty,IStartItems
    {
        public enum WeaponState //состояние оружия
        {
            Bad,
            Normal,
            Good
        }
        public WeaponState State { get; set; }
        public int Strenght { get; set; } = 5; //скилл ярость + к урону
        public string Helmet { get; set; } = "5"; //шлем, защита от физ урона
        public override object[] PersonalItem => new object[] { Helmet };
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
            Console.WriteLine($"State, Rage, Health, MovementSpeed, AttackSpeed, Dexterity, Armor ");
        }
        public override void PrintItems()
        {
            Console.WriteLine($"Helmet, Boots, Cloak, HealingPotion");
        }
    }
}