using Task9.Items;

namespace Task9.Сharacters
{
    public class Bard : Character
    {
        public int Сharisma { get; set; } = 8; //наличие харизмы(может купить по скидке)
        public bool Mood { get; set; } = true; // если тру, то немного хилит        
        public override string[] UniqueCharacteristics => new string[] { nameof(Сharisma), nameof(Mood) };

        public Bard()
        {
            Items.Add(new Item(ItemsNames.Lute, "+5 к харизме"));
        }      
    }
}
