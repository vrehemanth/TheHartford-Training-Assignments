/*
    Exercise 4:
    Create an applicaƟon to produce an Electricity bill using console applicaƟon with proper format. Draw
    Boxes, lines and columns using characters only.
    For input get CustomerId, CustomerName, Address, PhoneNumber, EmailId, Type of connecƟon
    (Industrial, Business, DomesƟc, Agricultural), Previous Reading, Current Reading.
    Calculate Unit Consumed and decide Electricity charges on slab basis as:
    First 100 units  ₹1.5 / Unit consumed
    Next 150 units  ₹2.5 / Unit consumed
    Next 300 units  ₹4.5 / Unit consumed
    Above 1000 Units  ₹7.5 / Unit consumed
    Meter Rent based on Category should be charged as fixed amount.
    Industrial  2500
    Business  1500
    DomesƟc  1000
    Agricultural  Free
*/

namespace Exercise_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the following details:\n");
            Console.Write("Customer ID: ");
            string customerId = Console.ReadLine();

            Console.Write("Customer Name: ");
            string customerName = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("Phone Number: ");
            string phone = Console.ReadLine();

            Console.Write("Email ID: ");
            string email = Console.ReadLine();

            Console.Write("Connection Type (Industrial/Business/Domestic/Agricultural): ");
            string connectionType = Console.ReadLine();

            Console.Write("Previous Reading: ");
            string s=Console.ReadLine();
            int.TryParse(s,out int prevReading);

            Console.Write("Current Reading: ");
            string t=Console.ReadLine();
            int.TryParse(t, out int currReading);

            int unitsConsumed = currReading - prevReading;
            double energyCharge = CalculateBill(unitsConsumed);
            double meterRent = GetMeterRent(connectionType);
            double totalAmount = energyCharge + meterRent;

            Console.WriteLine("┌──────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                  ELECTRICITY BILL                        │");
            Console.WriteLine("├──────────────────────────────────────────────────────────┤");
            Console.WriteLine($"│ Customer ID       : {customerId,-37}│");
            Console.WriteLine($"│ Customer Name     : {customerName,-37}│");
            Console.WriteLine($"│ Address           : {address,-37}│");
            Console.WriteLine($"│ Phone Number      : {phone,-37}│");
            Console.WriteLine($"│ Email ID          : {email,-37}│");
            Console.WriteLine($"│ Connection Type   : {connectionType,-37}│");
            Console.WriteLine("├──────────────────────────────────────────────────────────┤");
            Console.WriteLine($"│ Previous Reading  : {prevReading,-37}│");
            Console.WriteLine($"│ Current Reading   : {currReading,-37}│");
            Console.WriteLine($"│ Units Consumed    : {unitsConsumed,-37}│");
            Console.WriteLine("├──────────────────────────────────────────────────────────┤");
            Console.WriteLine($"│ Energy Charges    : Rs. {energyCharge,-33}│");
            Console.WriteLine($"│ Meter Rent        : Rs. {meterRent,-33}│");
            Console.WriteLine("├──────────────────────────────────────────────────────────┤");
            Console.WriteLine($"│ TOTAL AMOUNT      : Rs. {totalAmount,-33}│");
            Console.WriteLine("└──────────────────────────────────────────────────────────┘");


            Console.WriteLine();
        }
        static double CalculateBill(int units)
        {
            double amount = 0;

            if (units <= 100)
                amount = units * 1.5;
            else if (units <= 250)
                amount = (100 * 1.5) + ((units - 100) * 2.5);
            else if (units <= 550)
                amount = (100 * 1.5) + (150 * 2.5) + ((units - 250) * 4.5);
            else
                amount = (100 * 1.5) + (150 * 2.5) + (300 * 4.5) + ((units - 550) * 7.5);

            return amount;
        }

        static double GetMeterRent(string type)
        {
            switch (type.ToLower())
            {
                case "industrial":
                    return 2500;
                case "business":
                    return 1500;
                case "domestic":
                    return 1000;
                case "agricultural":
                    return 0;
                default:
                    return 0;
            }
        }
    }
}
