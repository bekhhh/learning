Console.WriteLine("Введите текст:");
while (true) 
{ 
var input = Console.ReadLine();
    var words = input.Split(' ');
    var dictionary = new Dictionary<string, List<int>>();
    for (int i = 0; i < words.Length; i++) 
    { 
    var  word = words[i];
        if (!dictionary.ContainsKey(word))
        {
            dictionary[word] = new List<int>();
        }
        else 
        { 
        dictionary.Add(word, new List<int>());
        }
       
    }
}