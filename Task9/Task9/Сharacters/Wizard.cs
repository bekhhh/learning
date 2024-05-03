namespace Task9.Сharacters
{
    public class Wizard : Character
    {
        public int Mana { get; set; } = 5; //наличие маны
        public int MagicResistance { get; set; } = 5; //маг резист
        public Item Staff { get; set; } = new Item("Staff"); // наличие посоха

        public Wizard()
        {
            Items.Add(Staff);
        }
        public override void PrintСharacteristic()
        {
            base.PrintСharacteristic();
            Console.WriteLine($"{nameof(Mana)}, {nameof(MagicResistance)}");
        }
    }
}