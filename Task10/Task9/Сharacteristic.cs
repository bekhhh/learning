namespace Task9
{
    public abstract class Сharacteristic
    {
        public enum StartItems
        {
            Boots,
            Cloak,
            HealingPotion
        }
        public abstract StartItems[] CharacterStartItems { get; }
        public abstract double Health { get; set; }
        public abstract int MovementSpeed { get; set; } 
        public abstract int AttackSpeed { get; set; }
        public abstract int Dexterity { get; set; }
        public abstract double Armor { get; set; }
        public abstract void PrintСharacteristic();
        public abstract void PrintItems();
    }
}