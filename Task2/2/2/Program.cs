using System.Diagnostics.Tracing;
using static System.Net.Mime.MediaTypeNames;

public class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            var input = Console.ReadLine();
            if (input == "End")
            {
                break;
            }
            else
            {
                var words = input.Split(' '); //разделил
                for (int i = 0; i < words.Length; i++)
                {
                    var reversedWord = "";
                    for (int j = words[i].Length - 1; j >= 0; j--)
                    {
                        reversedWord += words[i][j]; // тут начиная с первого for идет процесс переворачивания
                    }
                    words[i] = reversedWord; // тут заменил переменной
                }
                var reversedString = string.Join(" ", words); //собрал
                Console.WriteLine(reversedString); // вывел на консоль
            }
        }
    }
}