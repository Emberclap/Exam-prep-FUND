internal class Program
{
    static void Main(string[] args)
    {
        int numberOfPieces = int.Parse(Console.ReadLine());
        List<Pieces> pieces = new List<Pieces>();
        for (int i = 0; i < numberOfPieces; i++)
        {
            string[] piece = Console.ReadLine()
                .Split('|')
                .ToArray();
            string pieceName = piece[0];
            string composerName = piece[1];
            string key = piece[2];
            pieces.Add(new Pieces(pieceName, composerName, key));
        }
        string input = string.Empty;
        while ((input = Console.ReadLine()) != "Stop")
        {
            string[] commands = input
            .Split('|')
            .ToArray();
            string pieceName = commands[1];
            switch (commands[0])
            {
                case "Add":
                    string composerName = commands[2];
                    string key = commands[3];
                    if (pieces.Any(x => x.Name == pieceName))
                    {
                        Console.WriteLine($"{pieceName} is already in the collection!");
                    }
                    else
                    {
                        pieces.Add(new Pieces(pieceName, composerName, key));
                        Console.WriteLine($"{pieceName} by {composerName} in {key} added to the collection!"
);
                    }
                    break;
                case "Remove":

                    if (pieces.Any(x => x.Name == pieceName))
                    {
                        pieces.Remove(pieces.First(x => x.Name == pieceName));
                        Console.WriteLine($"Successfully removed {pieceName}!");
                    }   
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                    }
                    break;
                case "ChangeKey":
                    string keyValue = commands[2];
                    if (!pieces.Any(x => x.Name == pieceName))
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");

                    }
                    else
                    {
                        pieces.First(x =>x.Name == pieceName).Key = keyValue;
                        Console.WriteLine($"Changed the key of {pieceName} to {keyValue}!");
                    }
                    break;
            }

        }
        foreach (var piece in pieces)
        {
            Console.WriteLine($"{piece.Name} -> Composer: {piece.Composer}, Key: {piece.Key}");
        }
    }
    public class Pieces
    {
        public Pieces(string name, string composer, string key)
        {
            Name = name;
            Composer = composer;
            Key = key;
        }

        public string Name { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }
        
    }
}
