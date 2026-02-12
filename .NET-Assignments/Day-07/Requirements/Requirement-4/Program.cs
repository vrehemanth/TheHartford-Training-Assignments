// Parking Lot - Requirement-4

namespace Requirement_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                VehicleBO vehicleBO = new VehicleBO();
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

                // Search menu
                Console.WriteLine("\nEnter a search type:");
                Console.WriteLine("1.By type");
                Console.WriteLine("2.By parked time");

                int.TryParse(Console.ReadLine(), out int choice);

                List<Vehicle> result = new List<Vehicle>();

                //Search by Vehicle Type
                if (choice == 1)
                {
                    Console.Write("\nEnter the vehicle type: ");
                    string type = Console.ReadLine();

                    result = vehicleBO.FindVehicle(vehicleList, type);
                }
                // Search by Parked time
                else if (choice == 2)
                {
                    Console.Write("\nEnter the parked time (dd-MM-yyyy HH:mm:ss): ");
                    DateTime parkedTime = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy HH:mm:ss",
                                          null);

                    result = vehicleBO.FindVehicle(vehicleList, parkedTime);
                }
                // Display result
                if (result.Count == 0)
                {
                    Console.WriteLine("No vehicles found");
                }
                else
                {
                    Console.WriteLine("\n{0,-20} {1,-10} {2,-12} {3,-7} {4}",
                        "Registration No", "Name", "Type", "Weight", "Ticket No"
                    );

                    foreach (Vehicle v in result)
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
            // Invalid inputs
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please check numeric and date values.");
            }
            // Null or empty arguments
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Some other Exceptions
            catch (Exception)
            {
                Console.WriteLine("An unexpected error occurred.");
            }
        }
    }
}
