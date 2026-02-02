// Remove Duplicates (Distinct())
using System.Transactions;

namespace Duplicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter numbers in the array: ");
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse).Distinct().ToArray();

            Console.WriteLine("After removing duplicates: ");
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
