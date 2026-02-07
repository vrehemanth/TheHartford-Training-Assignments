// ParkingLot - Requirement 2

namespace Requirement_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter the name of the Parking Lot: ");
                string parkingLotName = Console.ReadLine();

                // Create ParkingLot object 
                ParkingLot parkingLot = new ParkingLot(parkingLotName, new List<Vehicle>());

                int choice;
                do
                {
                    // Display menu
                    Console.WriteLine("\n1.Add Vehicle");
                    Console.WriteLine("2.Delete Vehicle");
                    Console.WriteLine("3.Display Vehicles");
                    Console.WriteLine("4.Exit");
                    Console.WriteLine("Enter -1 to Exit\n");
                    Console.Write("Enter your choice: ");

                    int.TryParse(Console.ReadLine(), out choice);

                    switch (choice)
                    {
                        // Add Vehicle
                        case 1:
                            Console.Write("\nEnter Vehicle details: ");
                            string input = Console.ReadLine();

                            // Create vehicle using static method
                            Vehicle vehicle = Vehicle.CreateVehicle(input);

                            parkingLot.AddVehicleToParkingLot(vehicle);
                            Console.WriteLine("Vehicle successfully added");
                            break;

                        // Delete Vehicle
                        case 2:
                            Console.Write("Enter Regsitration Number: ");
                            string regNo = Console.ReadLine();

                            bool result = parkingLot.RemoveVehicleFromParkingLot(regNo);

                            if (result)
                                Console.WriteLine("Vehicle successfully deleted");
                            else
                                Console.WriteLine("Vehicle not found in parkinglot");
                            break;

                        // Display Vehicles
                        case 3: parkingLot.DisplayVehicles(); break;

                        // Exit 
                        case -1: Console.WriteLine("Exiting Program..."); return;

                        default: Console.WriteLine("Invalid choice"); break;
                    }
                } while (choice != -1);
            }
            // To print Exception message
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
