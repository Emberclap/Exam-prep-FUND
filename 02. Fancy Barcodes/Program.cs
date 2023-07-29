using System.Text;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    internal class Program
    {
        static void Main()
        {
            string pattern = @"(\@)([#]+)([A-Z][A-Za-z0-9]{4,}[A-Z])(\@)([#]+)";
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                string barrcode = Console.ReadLine();
                
                if (!Regex.IsMatch(barrcode, pattern))
                {
                    Console.WriteLine("Invalid barcode");
                }
                else
                {
                    StringBuilder productGroup = new StringBuilder();
                    foreach (char c in barrcode)
                    {
                        if (char.IsDigit(c))
                        {
                            productGroup.Append(c);
                        }
                    }
                    if (productGroup.Length > 0)
                    {
                        Console.WriteLine($"Product group: {productGroup}");
                    }
                    else
                    {
                        Console.WriteLine("Product group: 00");
                    }
                }
            }
            
        }
    }
}