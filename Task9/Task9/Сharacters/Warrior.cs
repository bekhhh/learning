namespace Task9.Сharacters
{
    public class Warrior : Character
    {
        public enum WeaponState //состояние оружия
        {
            Bad,
            Normal,
            Good
        }
        public WeaponState State { get; set; }
        public int Strenght { get; set; } = 5; //скилл ярость + к урону
        public Item Helmet { get; set; } = new Item("Helmet"); //шлем, защита от физ урона

        public Warrior()
        {
            Items.Add(Helmet);
        }
        public override void PrintСharacteristic()
        {
            base.PrintСharacteristic();
            Console.WriteLine($"{nameof(State)}, {nameof(Strenght)}");
        }
    }
}