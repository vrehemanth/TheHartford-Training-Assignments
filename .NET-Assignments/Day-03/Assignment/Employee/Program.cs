// Department-wise Employee Salaries (Jagged Array)
namespace Employee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of departments: ");
            int.TryParse(Console.ReadLine(), out int deptCount);

            string[] deptNames = new string[deptCount];
            int[][] salaries = new int[deptCount][];

            for (int i = 0; i < deptCount; i++)
            {
                Console.Write($"\nEnter name of department {i + 1}: ");
                deptNames[i] = Console.ReadLine();

                Console.Write($"Enter number of employees in {deptNames[i]}: ");
                int.TryParse(Console.ReadLine(), out int empCount);

                salaries[i] = new int[empCount];

                for (int j = 0; j < empCount; j++)
                {
                    Console.Write($"Enter salary of employee {j + 1} in {deptNames[i]}: ");
                    int.TryParse(Console.ReadLine(), out salaries[i][j]);
                }
            }

            Console.WriteLine("\n---- Salary Details ----");
            for (int i = 0; i < deptCount; i++)
            {
                Console.WriteLine($"\nDepartment: {deptNames[i]}");
                Console.Write("Salaries are: ");
                foreach (int sal in salaries[i])
                {
                    Console.WriteLine(sal);
                }
            }
        }
    }
}
