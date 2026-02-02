// Swap Numbers using ref (Parameter Types)
namespace SwapTwoNumbers
{
    internal class Program
    {
        static void swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            int.TryParse(Console.ReadLine(),out int x);
            Console.Write("Enter second number: ");
            int.TryParse(Console.ReadLine(), out int y);
            swap(ref x, ref y);
            Console.WriteLine($"Numbers after swapping are: {x} {y}");
        }
    }
}
