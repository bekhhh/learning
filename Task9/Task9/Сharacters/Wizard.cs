using Task9.Items;

namespace Task9.Сharacters
{
    public class Wizard : Character
    {
        public int Mana { get; set; } = 5; //наличие маны
        public int MagicResistance { get; set; } = 5; //маг резист
        public Item Staff { get; set; } = new Item(ItemsNames.Staff); // наличие посоха
        public override string[] UniqueCharacteristics => new string[] { nameof(Mana), nameof(MagicResistance) };

        public Wizard()
        {
            Items.Add(new Item(ItemsNames.Staff));
        }
    }
}