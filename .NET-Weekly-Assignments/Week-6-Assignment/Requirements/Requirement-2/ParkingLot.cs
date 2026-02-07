using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_2
{
    internal class ParkingLot
    {
        // Private fields to store ParkingLot details
        private string _name;
        private List<Vehicle>_vehicleList;

        //Public property to get/set parking lot name
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        //Public property to get/set Vehicle List
        public List<Vehicle> VehicleList
        {
            get { return _vehicleList; }
            set { _vehicleList = value; }
        }

        // Default Constructor
        public ParkingLot()
        {
            _vehicleList = new List<Vehicle>();
        }

        // Parameterized Constructor
        public ParkingLot(string _name, List<Vehicle> _vehicleList)
        {
            this._name = _name;
            this._vehicleList = new List<Vehicle>();
        }

        // Add Vehicle
        public void AddVehicleToParkingLot(Vehicle vehicle)
        {
            _vehicleList.Add(vehicle);
        }

        // Remove Vehicle
        public bool RemoveVehicleFromParkingLot(string registrationNo)
        {
            foreach (Vehicle v in _vehicleList)
            {
                if (string.Equals(v.RegistrationNo, registrationNo, StringComparison.OrdinalIgnoreCase))
                {
                    _vehicleList.Remove(v);
                    return true;
                }
            }
            return false;
        }

        // Display Vehicles in parking lot
        public void DisplayVehicles()
        {
            if (_vehicleList.Count == 0)
            {
                Console.WriteLine("No vehicles to show");
                return;
            }

            Console.WriteLine($"\nVehicles in {Name}\n");
            Console.Write("{0,-20} {1,-10} {2,-12} {3,-7} {4}\n",
                          "Registration No", "Name", "Type", "Weight", "Ticket No");

            foreach (Vehicle v in _vehicleList)
            {
                Console.Write("{0,-20} {1,-10} {2,-12} {3,-7:F1} {4}\n",
                              v.RegistrationNo,
                              v.Name,
                              v.Type,
                              v.Weight,
                              v.Ticket.TicketNo);
            }
        }
    }
}
