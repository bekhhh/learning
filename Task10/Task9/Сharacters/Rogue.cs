namespace Task9.Сharacters
{
    public class Rogue : Сharacteristic
    {
        public bool NightVision { get; set; }
        public bool Invisibility { get; set; }
        public string Dagger { get; set; }
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
            Console.WriteLine($"NightVision, Invisibility, Health, MovementSpeed, AttackSpeed, Dexterity, Armor ");
        }
        public override void PrintItems()
        {
            Console.WriteLine($"Dagger, Boots, Cloak, HealingPotion");
        }
    }
}
