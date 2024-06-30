using Task9.Items;

namespace Task9.Сharacters
{
    public class Cleric : Character
    {
        public int Heal { get; set; } = 2; //скилл лечения
        public int MagicResistance { get; set; } = 5;  //  маг резист
        public override string[] UniqueCharacteristics => new string[] { nameof(Heal), nameof(MagicResistance) };

        public Cleric()
        {
            Items.Add(new Item(ItemsNames.FirstAidKit, "Восстанавливает 30 единиц здоровья"));
        }
    }
}
