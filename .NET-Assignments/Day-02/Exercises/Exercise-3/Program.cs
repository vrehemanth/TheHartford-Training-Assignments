/*
    Exercise: 3

    An organization wants to calculate an employee’s Net Salary based on:
    Basic Salary
    HRA = 20% of Basic
    DA = 10% of Basic
    PF = 12% of Basic
    If Basic Salary < 15,000 → No PF deducƟon.
    Create a Class Library named SalaryCalculator and create a method in library as signature below:
    public staƟc double CalculateNetSalary(double basicSalary)
    Consume this library in a console applicaƟon.Get proper details of an individual Employee and display
    proper result.Implement Basic Exception Handling also in Library
*/

using System;
using SalaryCalculator;
namespace Exercise_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Net Salary Calculation\n");
            Console.Write("Enter Basic Salary: ");
            string s= Console.ReadLine();
            double.TryParse(s,out double sal);
            double netSal=SalaryCalculation.CalculateNetSalary(sal);
            Console.WriteLine("Net Salary = " + netSal);
        }
    }
}
