using Task9.Characteristics;
using Task9.Items;

namespace Task9.Сharacters
{
    public class Warrior : Character
    {        
        public WeaponState State { get; set; }
        public int Strenght { get; set; } = 5; //скилл ярость + к урону
        public override string[] UniqueCharacteristics => new string[] { nameof(State), nameof(Strenght) };

        public Warrior()
        {
            Items.Add(new Item(ItemsNames.Helmet, "+3 к броне"));
        }
    }
}