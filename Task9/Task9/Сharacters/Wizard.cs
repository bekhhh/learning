using Task9.Items;

namespace Task9.Сharacters
{
    public class Wizard : Character
    {
        public int Mana { get; set; } = 5; //наличие маны
        public int MagicResistance { get; set; } = 5; //маг резист
        public override string[] UniqueCharacteristics => new string[] { nameof(Mana), nameof(MagicResistance) };

        public Wizard()
        {
            Items.Add(new Item(ItemsNames.Staff, "+7 к урону"));
        }
    }
}