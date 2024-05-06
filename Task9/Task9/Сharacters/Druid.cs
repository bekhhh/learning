using Task9.Items;

namespace Task9.Сharacters
{
    public class Druid : Character
    {
        public bool ForestArmor { get; set; } = false;//если в лесу + армор
        public int Vision { get; set; } = 10; //хороший слух
        public Item Summoner { get; set; } = new Item(ItemsNames.Summoner); //имеет саммонера
        public override string[] UniqueCharacteristics => new string[] { nameof(ForestArmor), nameof(Vision) };

        public Druid()
        {
            Items.Add(new Item(ItemsNames.Summoner));
        }
    }
}
