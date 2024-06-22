using Newtonsoft.Json;
using System.Xml;
using Task9.Items;
using Task9.Сharacters.Ability;

namespace Task9
{
    public abstract class Character
    {       
        [JsonIgnore]
        public abstract string[] UniqueCharacteristics { get; }
        public double Health { get; set; } = 10;
        public int MovementSpeed { get; set; } = 5;
        public int AttackSpeed { get; set; } = 5;
        public int Dexterity { get; set; } = 5;
        public double Armor { get; set; } = 10;
        public List<Item> Items { get; set; } = new List<Item>();
        [JsonIgnore]
        public List<Ability> Abilities { get; set; } = new List<Ability>();

        public Character()
        {
            Items = new List<Item>
            {
                new Item(ItemsNames.Boots, "+5 к скорости передвижения"),
                new Item(ItemsNames.HealingPotion, "Восстанавливает 50 единиц здоровья"),
                new Item(ItemsNames.Cloack, "+1 к броне")
            };
        }
        public void PrintСharacteristic()
        {
            Console.WriteLine($"{string.Join(", ", UniqueCharacteristics)}, {nameof(Health)}," +
                $" {nameof(MovementSpeed)}, {nameof(AttackSpeed)}, {nameof(Dexterity)}, {nameof(Armor)}");
        }

        public void PrintItems()
        {
            Console.WriteLine(string.Join(", ", Items.Select(i => i.Name)));
        }

        public void PrintJson()
        {           
            Console.WriteLine(JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented));
        }

        public void PrintInfo() 
        {
            var json = JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
            var abilitiesJson = JsonConvert.SerializeObject(Abilities, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(json);
            Console.WriteLine("Abilities:");
            Console.WriteLine(abilitiesJson);
        }
    }
}