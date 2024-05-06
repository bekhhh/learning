using Task9.Items;

namespace Task9.Сharacters
{
    public class Rogue : Character
    {
        public bool NightVision { get; set; } = false; //видит дадьше, если ночь
        public bool Invisibility { get; set; } = false; //скилл невидимость
        public Item Dagger { get; set; } = new Item(ItemsNames.Dagger); //наличие клинка + отравление
        public override string[] UniqueCharacteristics => new string[] { nameof(NightVision), nameof(Invisibility) };

        public Rogue()
        {
            Items.Add(new Item(ItemsNames.Dagger));
        }
    }
}
