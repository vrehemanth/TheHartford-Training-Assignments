namespace Requirement_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();

            // Read number of vehicles
            Console.Write("Enter the number of vehicles: ");
            int n = int.Parse(Console.ReadLine());

            // Read vehicle details
            Console.WriteLine("\nEnter Vehicle Details: ");
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Vehicle v = Vehicle.CreateVehicle(input);
                vehicleList.Add(v);
            }

            // Search menu
            Console.WriteLine("\nEnter a type to sort:");
            Console.WriteLine("1.Sort by weight");
            Console.WriteLine("2.Sort by parked time");
            
            int.TryParse(Console.ReadLine(),out int choice);

            List<Vehicle> result = new List<Vehicle>();

            //Search by Vehicle Type
            if (choice == 1)
            {
                vehicleList.Sort();
            }
            // Search by Parked time
            else if (choice == 2)
            {
                vehicleList.Sort(new ParkedTimeComparer());
            }
            // Display result
            Console.WriteLine("\n{0,-20} {1,-10} {2,-12} {3,-7} {4}",
                "Registration No", "Name", "Type", "Weight", "Ticket No"
            );
            foreach (Vehicle v in vehicleList)
            {
                Console.WriteLine(
                    "{0,-20} {1,-10} {2,-12} {3,-7:F1} {4}",
                    v.RegistrationNo,
                    v.Name,
                    v.Type,
                    v.Weight,
                    v.Ticket.TicketNo
                );
            }
        }
    }
}
