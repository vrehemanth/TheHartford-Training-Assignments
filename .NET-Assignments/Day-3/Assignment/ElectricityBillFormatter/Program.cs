// Electricity Bill Formatter (String.Format + Alignment)
using System;
namespace ElectricityBillFormatter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of units consumed: ");
            double.TryParse(Console.ReadLine(), out double units);
            double amount = units * 6.5;
            string bill = String.Format("Units: {0,-10}\nAmount: Rs {1:F2}",units, amount);
            Console.WriteLine(bill);
        }
    }
}
