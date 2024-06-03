namespace Task9
{
    public class Ability
    {
        public string Name { get; }
        public string Description { get; set; }
        public int Mana { get; set; }
        public Elements Elements { get; set; }
        public Ability(string name, string description, int mana, Elements elements)
        {
            Name = name;
            Description = description;
            Mana = mana;
            Elements = elements;
        }
    }
}
