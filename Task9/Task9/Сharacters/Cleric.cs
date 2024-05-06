using Task9.Items;

namespace Task9.Сharacters
{
    public class Cleric : Character
    {
        public int Heal { get; set; } = 2; //скилл лечения
        public int MagicResistance { get; set; } = 5;  //  маг резист
        public Item FirstAidKit { get; set; } = new Item(ItemsNames.FirstAidKit); // аптечка
        public override string[] UniqueCharacteristics => new string[] { nameof(Heal), nameof(MagicResistance) };

        public Cleric()
        {
            Items.Add(new Item(ItemsNames.FirstAidKit));
        }
    }
}
