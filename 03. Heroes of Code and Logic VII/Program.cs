using System.Security.Cryptography.X509Certificates;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Hero> heroes = new List<Hero>();
            for (int i = 0; i < n; i++)
            {
                string[] hero = Console.ReadLine()
                    .Split()
                    .ToArray();
                string heroName = hero[0];
                int heroHealth = int.Parse(hero[1]);
                int heroMana = int.Parse(hero[2]);
                heroes.Add(new Hero(heroName, heroHealth, heroMana));
            }
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input
                    .Split(" - ")
                    .ToArray();
                string heroName = commands[1];
                switch (commands[0])
                {
                    case "CastSpell":
                        string spellName = commands[3];
                        int manaNeeded = int.Parse(commands[2]);
                        foreach (Hero hero in heroes)
                        {
                            if (hero.Name == heroName)
                            {
                                if (hero.MP >= manaNeeded)
                                {
                                     hero.MP -= manaNeeded;
                                     Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {hero.MP} MP!");
                                }
                                else
                                {
                                    Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                                }
                            }
                            
                        }
                        break;
                    case "TakeDamage":
                        int damage = int.Parse(commands[2]);
                        string attacker = commands[3];
                        foreach (Hero hero in heroes)
                        {
                            if (hero.Name == heroName)
                            {
                                hero.HP -= damage;
                                if (hero.HP <= 0)
                                {
                                    heroes.Remove(hero);
                                    Console.WriteLine($"{hero.Name} has been killed by {attacker}!");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"{hero.Name} was hit for {damage} HP by {attacker} and now has {hero.HP} HP left!");
                                }
                            }
                        }
                        break;
                    case "Recharge":
                        int manaRecharge = int.Parse(commands[2]);
                        foreach(Hero hero in heroes)
                        {
                            if (hero.Name == heroName)
                            {
                                if (hero.MP + manaRecharge > 200)
                                {
                                    Console.WriteLine($"{hero.Name} recharged for {200-hero.MP} MP!");
                                    hero.MP = 200;
                                }
                                else
                                {
                                    hero.MP += manaRecharge;
                                    Console.WriteLine($"{hero.Name} recharged for {manaRecharge} MP!");
                                }
                            }
                        }
                        break;
                    case "Heal":
                        int heal = int.Parse(commands[2]);
                        foreach (Hero hero in heroes)
                        {
                            if (hero.Name == heroName)
                            {
                                if (hero.HP + heal > 100)
                                {
                                    Console.WriteLine($"{hero.Name} healed for {100 - hero.HP} HP!");
                                    hero.HP = 100;
                                }
                                else
                                {
                                    hero.HP += heal;
                                    Console.WriteLine($"{hero.Name} healed for {heal} HP!");
                                }
                            }
                        }
                        break;
                }
            }
            foreach (Hero hero in heroes)
            {
                Console.WriteLine(hero.Name);
                Console.WriteLine($"HP: { hero.HP}");
                Console.WriteLine($"MP: {hero.MP}");
            }

        }
    }
    public class Hero
    {
        public Hero(string name, int healthPoints, int manaPoints)
        {
            Name = name;
            HP = healthPoints;
            MP = manaPoints;
        }

        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
    }
}