namespace _03._The_Pianist
{
    public class Program
    {
        
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Plant> plants = new List<Plant>();
            for (int i = 0; i < n; i++)
            {
                string[] plantInfo = Console.ReadLine()
                    .Split("<->")
                    .ToArray();
                string plantName = plantInfo[0];
                int plantRarity = int.Parse(plantInfo[1]);

                if (plants.Any(x => x.Name == plantName))
                {
                    plants.Find(x => x.Name == plantName).Rarity = plantRarity;
                }
                else
                {
                    plants.Add(new Plant(plantName, plantRarity));
                }
            }
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Exhibition")
            {
                string[] commands = input
                    .Split(new string[] {": " ," - " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string plantName = commands[1];
                if (!plants.Any(x => x.Name == plantName))
                {
                    Console.WriteLine("error");
                    continue;
                }
                switch (commands[0])
                {

                    case "Rate":
                        int rating = int.Parse(commands[2]);
                        plants.Find(x => x.Name == plantName).Rating.Add(rating);
                        break;
                    case "Update":
                        int rarity = int.Parse(commands[2]);
                        plants.Find(x=> x.Name == plantName).Rarity = rarity;
                        break;
                    case "Reset":
                        plants.Find(x => x.Name == plantName).Rating.Clear();
                        break;
                }

            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in plants)
            {
                if (plant.Rating.Count == 0)
                {
                    plant.Rating.Add(0);
                }
                Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: {plant.Rating.Average():f2}");
            }
        }
    }
    public class Plant
    {
        public Plant(string name, int rarity)
        {
            Name = name;
            Rarity = rarity;
            Rating = new List<int>();
        }
        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<int> Rating { get; set; }
    }
}