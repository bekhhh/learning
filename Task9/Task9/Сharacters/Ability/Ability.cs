namespace Task9.Сharacters.Ability
{
    public class Ability
    {
        public string Name { get; }
        public string Description { get; set; }
        public int Mana { get; set; }
        public Element Element { get; set; }
        public Ability(string name, string description, int mana, Element element)
        {
            Name = name;
            Description = description;
            Mana = mana;
            Element = element;
        }
    }
}
