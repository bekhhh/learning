namespace Task10.Сharacters
{
    public class Wizard : Сharacteristic
    {
        public int Mana { get; set; }
        public int MagicResistance { get; set; }
        public int Staff { get; set; }
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
            Console.WriteLine($"Mana, MagicResistance, Health, MovementSpeed, AttackSpeed, Dexterity, Armor ");
        }
        public override void PrintItems()
        {
            Console.WriteLine($"Staff, Boots, Cloak, HealingPotion");
        }
    }
}