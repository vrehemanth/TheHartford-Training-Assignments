/*  
    Exercise 1:

    Mahendra Singh Dhoni has put up commendable achievements in his baƫng career with a boasƟng
    baƫng average of 51.08 (ODIs) & (38.09) in Tests and a striking rate of 89.27 (ODIs) & 59.11 (Tests). In
    a span of 10-11 years, not only has he become India’s most successful captain, but he’s also changed
    the limited-overs game in ways that one could only dream of.
    If his entire Test batting statistics are referred, the runs scored by Dhoni in the conƟnual matches
    followed a particular pattern of series. The series looks like 0, 6, 24, 60, 120, 210, 336, ...... Predict the
    runs scored by Dhoni in this pattern of series upto “N” matches. 
*/

using System;
namespace Exercise_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Runs scored by Dhoni in first N matches");
            Console.Write("Enter number of matches played: ");
            string s= Console.ReadLine();
            int.TryParse(s, out int n);
            Console.WriteLine("Runs Scored by Dhoni in "+n+" matches are: \n");
            for(int i=0; i < n; i++)
            {
                int runs = i * (i + 1) * (i + 2);
                Console.Write($"{runs} ");
            }
            Console.WriteLine();
        }
    }
}
