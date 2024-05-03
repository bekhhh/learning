namespace Task9
{
    public class Character
    {
        public double Health { get; set; } = 10;
        public int MovementSpeed { get; set; } = 5;
        public int AttackSpeed { get; set; } = 5;
        public int Dexterity { get; set; } = 5;
        public double Armor { get; set; } = 10;
        public List<Item> Items { get; set; } = new List<Item>();

        public Character()
        {
            Items = new List<Item>
            {
                new Item($"Boots, Cloack, HealingPotion")
            };
        }
        public virtual void PrintСharacteristic()
        {
            Console.Write($"{nameof(Health)}, {nameof(MovementSpeed)}, " +
                $"{nameof(AttackSpeed)}, {nameof(Dexterity)}, {nameof(Armor)}");
        }

        public void PrintItems()
        {
            foreach (var item in Items)
            {
                Console.WriteLine(string.Join(", ", Items.Select(i => i.Name)));
                break;
            }
        }
    }
}