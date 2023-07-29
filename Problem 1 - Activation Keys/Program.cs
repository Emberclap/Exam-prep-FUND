

using System.Text;
using System.Text.RegularExpressions;

internal class Program
{
    static void Main()
    {
        string text = Console.ReadLine();
        string input = string.Empty;
        while ((input = Console.ReadLine()) != "Generate")
        {
            string[] operations = input
                .Split(">>>")
                .ToArray();
            switch (operations[0])
            {
                case "Contains":
                    string substring = operations[1];
                    if (text.Contains(substring))
                    {
                        Console.WriteLine($"{text} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                    break;
                case "Flip":
                    int start = int.Parse(operations[2]);
                    int stop = int.Parse(operations[3]);
                    if (operations[1] == "Upper")
                    {
                        string temp = text.Substring(start, stop - start);
                        text = text.Replace(temp, temp.ToUpper());
                        Console.WriteLine(text);
                    }
                    else
                    {
                        string temp = text.Substring(start, stop - start);
                        text = text.Replace(temp, temp.ToLower());
                        Console.WriteLine(text);
                    }
                    break;
                case "Slice":
                    int startIndex = int.Parse(operations[1]);
                    int endIndex = int.Parse(operations[2]);
                    text = text.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(text);
                    break;
            }

        }
        Console.WriteLine($"Your activation key is: {text}");
    }
}
