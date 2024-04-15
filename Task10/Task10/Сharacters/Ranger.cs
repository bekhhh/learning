namespace Task10.Сharacters
{
    public class Ranger : Сharacteristic
    {
        public bool isHidden { get; set; }
        public string RangeAttack { get; set; }
        public string Bow { get; set; }
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
            Console.WriteLine($"isHidden, RangeAttack, Health, MovementSpeed, AttackSpeed, Dexterity, Armor ");
        }
        public override void PrintItems()
        {
            Console.WriteLine($"Bow, Boots, Cloak, HealingPotion");
        }
    }
}
