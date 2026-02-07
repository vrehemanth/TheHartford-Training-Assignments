namespace Requirement_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();

            // Read number of vehicles
            Console.Write("Enter the number of vehicles: ");
            int.TryParse(Console.ReadLine(),out int n);

            // Read vehicle details
            Console.WriteLine("\nEnter Vehicle Details: ");
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Vehicle v = Vehicle.CreateVehicle(input);
                vehicleList.Add(v);
            }
            SortedDictionary<string, int> vehicles = Vehicle.TypeWiseCount(vehicleList);
            Console.WriteLine("\n{0,-15} {1}\n", "Type", "No. of Vehicles");
            foreach(var  v in vehicles)
            {
                Console.WriteLine("{0,-15} {1}",v.Key,v.Value);
            }
        }
    }
}
