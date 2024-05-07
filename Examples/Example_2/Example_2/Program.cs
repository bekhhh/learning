// See https://aka.ms/new-console-template for more information
using Example_2.Dictionary;
Console.WriteLine("Hello, World!");

var map = new MyDictionary<string, int>();
Console.WriteLine(map.ToString());

for (int i = 0; i < 20; i++)
{
    map.Add(i.ToString(), i);
    Console.WriteLine(map.ToString());
}