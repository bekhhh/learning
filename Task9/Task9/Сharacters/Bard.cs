using Task9.Items;

namespace Task9.Сharacters
{
    public class Bard : Character
    {
        public int Сharisma { get; set; } = 8; //наличие харизмы(может купить по скидке)
        public bool Mood { get; set; } = true; // если тру, то немного хилит        
        public Item Lute { get; set; } = new Item(ItemsNames.Lute); //+ армор союзникам       

        public Bard()
        {
            Items.Add(Lute);
        }
        public override void PrintСharacteristic()
        {
            base.PrintСharacteristic();
            Console.WriteLine($"{nameof(Сharisma)}, {nameof(Mood)}");
        }
    }
}
