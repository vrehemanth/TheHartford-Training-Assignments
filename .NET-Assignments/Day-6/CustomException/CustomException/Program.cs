using System;

namespace CustomException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer c = new Customer("Rahul", 2453, 500);
            try
            {
                Console.Write("Enter amount to withdraw: ");
                int.TryParse(Console.ReadLine(),out int amount);
                c.withdraw(amount);
                Console.WriteLine($"Balance left: {500-amount}");
            }
            catch (BankException e)
            {
                Console.WriteLine("Transaction failed");
                e.inform();
            }
        }
    }
}
