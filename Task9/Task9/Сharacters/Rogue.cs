namespace Task9.Сharacters
{
    public class Rogue : Character
    {
        public bool NightVision { get; set; } = false; //видит дадьше, если ночь
        public bool Invisibility { get; set; } = false; //скилл невидимость
        public Item Dagger { get; set; } = new Item("Dagger"); //наличие клинка + отравление

        public Rogue()
        {
            Items.Add(Dagger);
        }
        public override void PrintСharacteristic()
        {
            base.PrintСharacteristic();
            Console.WriteLine($"{nameof(NightVision)}, {nameof(Invisibility)}");
        }
    }
}
