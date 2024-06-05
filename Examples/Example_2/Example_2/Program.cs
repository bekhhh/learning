// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using Example_2.Dictionary;
Console.WriteLine("Hello, World!");

// var map = new MyDictionary<string, int>();
// Console.WriteLine(map.ToString());
//
// for (int i = 0; i < 20; i++)
// {
//     map.Add(i.ToString(), i);
//     Console.WriteLine(map.ToString());
// }
//
// var asd = JsonSerializer.Serialize(map);
//

var array = new int[]
{
    1, 45, 6, 8, 5, 3, 6
};
var linkedList = new MyLinkedList<int>(array);

//
foreach (var item in linkedList)
{
    Console.WriteLine(item);
}
//
//Тоже самое что и
//
int item1;
var enumerator = linkedList.GetEnumerator();
while (enumerator.MoveNext())
{
    item1 = enumerator.Current;
    {
        Console.WriteLine(item1);
    }
}
//

var linkedListV2 = new MyLinkedListV2<int>(array);

//
foreach (var item in linkedListV2)
{
    Console.WriteLine(item);
}
//
//Тоже самое что и
//
int item2;
var enumeratorV2 = linkedListV2.GetEnumerator();
while (enumeratorV2.MoveNext())
{
    item2 = enumeratorV2.Current;
    {
        Console.WriteLine(item2);
    }
}
//

Console.WriteLine();
foreach (var item in new RofloClass())
{
    Console.WriteLine(item);
}