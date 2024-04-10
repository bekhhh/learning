using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var dictionary = new Dictionary<string,int>();
var filePath =@"C:\Projects\forTask.txt";
if (File.Exists(filePath))
{
    string[] lines = File.ReadAllLines(filePath);
    foreach (string line in lines)
    {
        var arrayOfStrings = line.Split(',')
            .Select(x => x.Trim())
            .Where(x => !string.IsNullOrEmpty(x))
            .ToArray();
        foreach (var symbols in arrayOfStrings) 
        {
            foreach (var text in File.ReadLines(filePath).Skip(1))
            {
                if (dictionary.ContainsKey(symbols)) 
                {
                    dictionary[symbols]++;
                }
            }
        }       
    }    
}