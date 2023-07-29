using System.Text.RegularExpressions;

namespace _02._Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(#|\|)(?<name>[A-Za-z\s]+)(\1)(?<date>\d{2}\/\d{2}\/\d{2})(\1)(?<calories>\d+)(\1)";
            string input = Console.ReadLine();

            List<Product> products = new List<Product>();
            
            foreach (Match match in Regex.Matches(input, pattern))
            {
                string productName = match.Groups["name"].Value;
                string expDate = match.Groups["date"].Value;
                int calories = int.Parse(match.Groups["calories"].Value);
                products.Add(new Product(productName, expDate, calories));
            }
            int days = products.Sum(x => x.Caloriues) / 2000;
            Console.WriteLine($"You have food to last you for: {days} days!");
            foreach (Product product in products)
            {
                Console.WriteLine($"Item: {product.Name}, Best before: {product.ExpDate}, Nutrition: {product.Caloriues}");
            }
        }
        
    }
    internal class Product
    {
        public Product(string name, string expirationDate, int calories)
        {
            Name = name;
            ExpDate = expirationDate;
            Caloriues = calories;
        }
        public string Name { get; set; }
        public string ExpDate { get; set; }
        public int Caloriues { get; set; }
    }
}