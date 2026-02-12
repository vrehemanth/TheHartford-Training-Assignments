// Secure Student Marks Analyzer (TryParse + Array)
using System;
namespace Student
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of students: ");
            int.TryParse(Console.ReadLine(), out int n);
            Console.WriteLine();
            int[] marks = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter marks of Student {i + 1}: ");
                int.TryParse(Console.ReadLine(), out marks[i]);
            }
            Console.WriteLine();
            Array.Sort(marks);
            Console.WriteLine($"Highest Marks: {marks[n - 1]}");
            Console.WriteLine($"Lowest Marks: {marks[0]}");
        }
    }
}
