namespace Task9.Сharacters
{
    public class Druid : Сharacteristic
    {
        public bool ForestArmor { get; set; }
        public int Hearing { get; set; }
        public string Summoner { get; set; }
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
            Console.WriteLine($"ForestArmor, Hearing, Health, MovementSpeed, AttackSpeed, Dexterity, Armor ");
        }
        public override void PrintItems()
        {
            Console.WriteLine($"Summoner, Boots, Cloak, HealingPotion");
        }
    }
}
