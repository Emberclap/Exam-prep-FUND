using System.Text.RegularExpressions;

namespace _02._Destination_Mapper
{
    internal class Program
    {
        static void Main()
        {
            string pattern = @"(\=|\/)([A-Z][A-z]{2,})(\1)";
            string text = Console.ReadLine();
            int points = 0;
            MatchCollection collection = Regex.Matches(text, pattern);
            List<string> destinations = new List<string>();
            foreach (Match match in collection)
            {
                points += match.Groups[2].Length;
                destinations.Add(match.Groups[2].Value);
            }
            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {points}");
        }
    }
}