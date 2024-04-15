namespace Task10.Сharacters
{
    public class Bard : Сharacteristic
    {
        public int Сharisma {get; set;}
        public string Mood { get; set;}
        public string Lute { get; set; }
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
            Console.WriteLine($"Сharisma, Mood, Health, MovementSpeed, AttackSpeed, Dexterity, Armor ");
        }
        public override void PrintItems()
        {
            Console.WriteLine($"Lute, Boots, Cloak, HealingPotion");
        }
    }
}
