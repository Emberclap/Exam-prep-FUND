using System.Text;

namespace _01._World_Tour
{
    internal class Program
    {
        static void Main()
        {
            string input = string.Empty;
            StringBuilder sb = new StringBuilder(input);
            
            while ((input = Console.ReadLine()) != "Travel")
            {
                if (sb.Length <= 0)
                {
                    sb.Append(input);
                }
                string[] commands = input
                    .Split(':')
                    .ToArray();
                switch (commands[0])
                {
                    case "Add Stop":
                        int index = int.Parse(commands[1]);
                        string destination = commands[2];
                        if (index >= 0 && sb.Length > index)
                        {
                            sb.Insert(index, destination);
                        }
                            Console.WriteLine(sb);
                        break;
                    case "Remove Stop":
                        int startIndex = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);
                        if (startIndex >= 0 && endIndex < sb.Length)
                        {
                            sb.Remove(startIndex, endIndex - startIndex+1);
                        }
                            Console.WriteLine(sb);
                        break;
                    case "Switch":
                        string newString = commands[2];
                        string oldString = commands[1];
                        sb.Replace(oldString, newString);
                        Console.WriteLine(sb);
                        break;
                }
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {sb}");
        }
    }
}