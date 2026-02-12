// Search & Validate Product Price
namespace Product
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] prices = { 100, 250, 500, 750 };

            Console.Write("Enter price to search: ");
            int.TryParse(Console.ReadLine(), out int p);

            bool found = Array.Exists(prices, x => x == p);
            Console.WriteLine(found ? "Price Found" : "Price Not Found");
        }
    }
}
