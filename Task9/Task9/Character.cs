using Task9.Items;

namespace Task9
{
    public abstract class Character
    {
        public abstract string[] UniqueCharacteristics { get; }
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
                new Item(ItemsNames.Boots),
                new Item(ItemsNames.HealingPotion),
                new Item(ItemsNames.Cloack)
            };
        }
        public virtual void PrintСharacteristic()
        {
            Console.WriteLine($"{string.Join(", ", UniqueCharacteristics)}, {nameof(Health)}," +
                $" {nameof(MovementSpeed)}, {nameof(AttackSpeed)}, {nameof(Dexterity)}, {nameof(Armor)}");

        }

        public void PrintItems()
        {
            Console.WriteLine(string.Join(", ", Items.Select(i => i.Name)));
        }
    }
}