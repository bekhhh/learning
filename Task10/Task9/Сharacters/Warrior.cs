namespace Task9.Сharacters
{
    public class Warrior : Сharacteristic
    {
        public enum WeaponState
        {
            Bad,
            Normal,
            Good
        }
        public WeaponState State { get; set; }
        public string Rage { get; set; }
        public string Helmet { get; set; }
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
            Console.WriteLine($"State, Rage, Health, MovementSpeed, AttackSpeed, Dexterity, Armor ");
        }
        public override void PrintItems()
        {
            Console.WriteLine($"Helmet, Boots, Cloak, HealingPotion");
        }
    }
}