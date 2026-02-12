// Shopping Cart Total (params)
namespace Shopping
{
    internal class Program
    {
        static int Total(params int[] prices)
        {
            int sum = 0;
            foreach (int p in prices) sum += p;
            return sum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Total: " + Total(100, 200, 300));
        }
    }
}
