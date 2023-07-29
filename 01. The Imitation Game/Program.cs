using System.Text;

namespace _01._The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Decode")
            {
                string[] instructions = input
                    .Split('|')
                    .ToArray();
                switch (instructions[0])
                {
                    case "Move": 
                        int numOfLetters = int.Parse(instructions[1]);
                       
                        string temp = message.Substring(0, numOfLetters);
                        message = message + temp;
                        message = message.Remove(0, numOfLetters);
                        break;
                    case "Insert":
                        int index = int.Parse(instructions[1]);
                        string value = instructions[2];
                        message = message.Insert(index, value);
                        break;
                    case "ChangeAll":
                        string substring = instructions[1];
                        string replacement = instructions[2];
                        if (message.Contains(substring))
                        {
                            message = message.Replace(substring, replacement);
                        }
                        break;
                }

            }
            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}