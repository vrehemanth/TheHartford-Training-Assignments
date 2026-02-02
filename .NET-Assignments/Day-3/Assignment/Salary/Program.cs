// Salary Increment System (ref + Array)
namespace Salary
{
    internal class Program
    {
        static void increase(ref int salary)
        {
            salary += 5000;
        }
        static void Main(string[] args)
        {
            int[] salaries = { 25000, 30000, 35000 };

            for (int i = 0; i < salaries.Length; i++)
            {
                increase(ref salaries[i]);
            }

            Console.WriteLine("Salary after increment:");
            Console.WriteLine(string.Join(" ", salaries));
        }
    }
}
