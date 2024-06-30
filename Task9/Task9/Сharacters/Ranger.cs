using Task9.Characteristics;
using Task9.Items;

namespace Task9.Сharacters
{
    public class Ranger : Character
    {
        public DrawLength Bow { get; set; }
        public bool IsHidden { get; set; } = false; //если да, то + урон
        public override string[] UniqueCharacteristics => new string[] { nameof(IsHidden), nameof(Bow) };

        public Ranger()
        {
            Items.Add(new Item(ItemsNames.PoisonArrows, "+10 к урону"));
        }
    }
}
