namespace Task9.Сharacters
{
    public class Druid : Character
    {
        public bool ForestArmor { get; set; } = false;//если в лесу + армор
        public int Vision { get; set; } = 10; //хороший слух
        public Item Summoner { get; set; } = new Item("Summoner"); //имеет саммонера

        public Druid()
        {
            Items.Add(Summoner);
        }
        public override void PrintСharacteristic()
        {
            base.PrintСharacteristic();
            Console.WriteLine($"{nameof(ForestArmor)}, {nameof(Vision)}");
        }
    }
}
