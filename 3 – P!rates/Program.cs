using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace _3___P_rates
{
    internal class Program
    {
        static void Main()
        {
            string input;
            List<City> cities = new List<City>();
            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] commands = input
                    .Split("||")
                    .ToArray();
                string cityName = commands[0];
                int cityPopulation = int.Parse(commands[1]);
                int cityGold = int.Parse(commands[2]);
                if (cities.Any(x => x.Name == cityName))
                {
                    cities.Find(x => x.Name == cityName).Population += cityPopulation;
                    cities.Find(x => x.Name == cityName).Gold += cityGold;
                }
                else
                {
                    cities.Add(new City(cityName, cityPopulation, cityGold));
                }
            }
            string input2;
            while ((input2 = Console.ReadLine())!= "End")
            {
                string[] commands = input2
                    .Split("=>")
                    .ToArray();

                switch (commands[0])
                {
                    case "Plunder":
                        string cityName = commands[1];
                        int citizensToKill = int.Parse(commands[2]);
                        int goldToSteal = int.Parse(commands[3]);
                        foreach (City city in cities)
                        {
                            if (city.Name == cityName)
                            {
                                city.Gold -= goldToSteal;
                                city.Population -= citizensToKill;
                                Console.WriteLine($"{city.Name} plundered! {goldToSteal} gold stolen, {citizensToKill} citizens killed.");
                                if (city.Gold <= 0 || city.Population <= 0)
                                {
                                    Console.WriteLine($"{city.Name} has been wiped off the map!");
                                    cities.Remove(city);
                                    break;
                                }
                            }
                            
                        }
                        break;
                    case "Prosper":
                        int goldToGrowth = int.Parse(commands[2]);
                        if (goldToGrowth < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                        }
                        else
                        {
                            foreach (City city in cities.Where(x => x.Name == commands[1]))
                            {
                                city.Gold += goldToGrowth;
                                Console.WriteLine($"{goldToGrowth} gold added to the city treasury. {city.Name} now has {city.Gold} gold.");
                            }
                            
                        }

                        break;
                }
            }
            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (City city in cities)
                {
                    Console.WriteLine($"{city.Name} -> Population: {city.Population} citizens, Gold: {city.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
    public class City 
    {
        public City(string name, int population, int gold)
        {
            Name = name;
            Population = population;
            Gold = gold;
        }

        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }
    }
}