using System.Text;

namespace _01._Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Done")
            {
                string[] commands = input
                    .Split()
                    .ToArray();

                switch (commands[0])
                {
                    case "TakeOdd":
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < password.Length; i++)
                        {
                            if (i % 2 == 1)
                            {
                                sb.Append(password[i]);
                            }
                        }
                        password = sb.ToString();
                        Console.WriteLine(password);
                        break;
                    case "Cut":
                        int cutIndex = int.Parse(commands[1]);
                        int cutLenght = int.Parse(commands[2]);
                        password = password.Remove(cutIndex, cutLenght);
                        Console.WriteLine(password);
                        break;
                    case "Substitute":
                        string stringToReplace = commands[1];
                        string newString = commands[2];
                        if (password.Contains(stringToReplace))
                        {
                            password = password.Replace(stringToReplace, newString);
                            Console.WriteLine(password);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        break;
                }
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}