namespace Task9.Сharacters
{
    public class Ranger : Character
    {
        public enum DrawLength // Длина растяжки (натяжения)
        {
            Weak,
            Normal,
            Strong
        }
        public DrawLength Bow { get; set; }
        public bool isHidden { get; set; } = false; //если да, то + урон
        public Item PoisonArrows { get; set; } = new Item("PoisonArrows"); //наличие отравленных стрел

        public Ranger()
        {
            Items.Add(PoisonArrows);
        }
        public override void PrintСharacteristic()
        {
            base.PrintСharacteristic();
            Console.WriteLine($"{nameof(isHidden)}, {nameof(PoisonArrows)}");
        }
    }
}
