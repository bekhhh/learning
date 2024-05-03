namespace Task9.Сharacters
{
    public class Cleric : Character
    {
        public int Heal { get; set; } = 2; //скилл лечения
        public int MagicResistance { get; set; } = 5;  //  маг резист
        public Item FirstAidKit { get; set; } = new Item("FirstAidKit"); // аптечка

        public Cleric()
        {
            Items.Add(FirstAidKit);
        }
        public override void PrintСharacteristic()
        {
            base.PrintСharacteristic();
            Console.WriteLine($"{nameof(Heal)}, {nameof(MagicResistance)}");
        }
    }
}
