using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string emojiPattern = @"([:]{2}|[*]{2})([A-Z][a-z]{2,})\1";
            string numbersPattern = @"\d";
            long threshold = 1;
            foreach (Match match in Regex.Matches(text, numbersPattern))
            {
                threshold *= int.Parse(match.Value);
            }
            Console.WriteLine($"Cool threshold: {threshold}"
);
            List<string> coolEmojiList = new List<string>();
            int emojisFound = 0;
            foreach (Match match in Regex.Matches(text,emojiPattern))
            {
                int emojiValue = 0;
                emojisFound++;
                string currentEmoji = match.Groups[2].Value;
                emojiValue += currentEmoji.Sum(x => (int)x);
                if (emojiValue >= threshold)
                {
                    coolEmojiList.Add(match.Value);
                }
            }
            Console.WriteLine($"{emojisFound} emojis found in the text. The cool ones are:");
            foreach (string emoji in coolEmojiList)
            {
                Console.WriteLine(emoji);
            }
        }
    }
}