namespace Task9.Items
{
    public class Item
    {
        public string Name { get; }
        public string Description { get; set; }
        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
