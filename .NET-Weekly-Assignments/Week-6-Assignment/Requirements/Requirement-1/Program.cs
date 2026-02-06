namespace Requirement_1
{
    internal class Program
    {
        // Reads a Single line of input
        static Vehicle ReadVehicle()
        {
            string[] data = Console.ReadLine().Split(',');
            string registrationNo = data[0];
            string name = data[1];
            string type = data[2];
            double weight = double.Parse(data[3]);
            string ticketNo = data[4];
            DateTime parkedTime = DateTime.Parse(data[5]);
            double cost = double.Parse(data[6]);

            Ticket ticket = new Ticket(ticketNo, parkedTime, cost);
            return new Vehicle(registrationNo, name, type, weight, ticket);
        }
        static void Main(string[] args)
        {
            // Enter details for first vehicle
            Console.WriteLine("Enter Vehicle 1 details:");
            Vehicle v1 = ReadVehicle();

            // Enter details for second vehicle
            Console.WriteLine("Enter Vehicle 2 details:");
            Vehicle v2 = ReadVehicle();

            Console.WriteLine();

            // Display details of Vehicle 1
            Console.WriteLine("Vehicle 1");
            Console.WriteLine(v1);
            Console.WriteLine();

            // Display details of Vehicle 2
            Console.WriteLine("Vehicle 2");
            Console.WriteLine(v2);
            Console.WriteLine();

            // Compare both vehicle objects
            if (v1.Equals(v2))
                Console.WriteLine("Vehicle 1 is same as Vehicle 2");
            else
                Console.WriteLine("Vehicle 1 is different from Vehicle 2");
        }
    }
}
