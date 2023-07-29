using System.Data.SqlTypes;
using System.Text;

namespace _01._Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string input = string.Empty;
            StringBuilder message = new StringBuilder(text); // on purpose | can do it w/o SB
            while ((input = Console.ReadLine()) != "Reveal")
            {
                
                string[] commands = input
                    .Split(":|:")
                    .ToArray();
                switch (commands[0])
                {
                    case "InsertSpace":
                        int index = int.Parse(commands[1]);
                        message.Insert(index, ' ');
                        Console.WriteLine(message);
                        break;
                    case "Reverse":
                        string textToReplace = commands[1];
                        if (message.ToString().Contains(textToReplace))
                        {
                            message.Remove(message.ToString().IndexOf(textToReplace), textToReplace.Length);
                            message.Append(new string(textToReplace.Reverse().ToArray()));
                        }
                        else
                        {
                            Console.WriteLine("error");
                            break;
                        }
                        Console.WriteLine(message);
                        break;
                    case "ChangeAll":
                        string oldText = commands[1];
                        string newText = commands[2];
                        message.Replace(oldText, newText);
                        Console.WriteLine(message);
                        break;
                }
            }
            Console.WriteLine($"You have a new text message: {message}");

        }
    }
}