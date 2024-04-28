using System.Security.Cryptography;
using Task9.Items;

namespace Task9.Сharacters
{
    public class Cleric : CharacterProperty,IStartItems
    {
        public int Heal { get; set; } = 2; //скилл лечения
        public int MagicResistance { get; set; } = 5;  //  маг резист
        public string FirstAidKit { get; set; } // аптечка
        public override object[] PersonalItem => new object[] { FirstAidKit };
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
            Console.WriteLine($"Heal, Jump, Health, MovementSpeed, AttackSpeed, Dexterity, Armor ");
        }
        public override void PrintItems()
        {
            Console.WriteLine($"FirstAidKit, Boots, Cloak, HealingPotion");
        }
    }
}
