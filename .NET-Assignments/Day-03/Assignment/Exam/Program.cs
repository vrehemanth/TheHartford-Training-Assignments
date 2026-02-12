// Exam Result Processor (Array + String.Format)
namespace Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] marks = { 88, 45, 92, 67, 55 };

            Array.Sort(marks);
            Array.Reverse(marks);

            for (int i = 0; i < marks.Length; i++)
            {
                Console.WriteLine(String.Format("Rank {0}: {1} marks", i + 1, marks[i]));
            }
        }
    }
}
