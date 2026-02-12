using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_4
{
    // c) Create a class VehicleBO
    internal class VehicleBO
    {
        // Find Vehicle by type
        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList, string type)
        {
            List<Vehicle> result = new List<Vehicle>();

            foreach (Vehicle v in vehicleList)
            {
                // Comparison of vehicle Type
                if (string.Equals(v.Type, type, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(v);
                }
            }
            return result;
        }
        // Find Vehicle by Parked time
        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList, DateTime parkedTime)
        {
            List<Vehicle> result = new List<Vehicle>();

            foreach (Vehicle v in vehicleList)
            {
                // Compare parked time
                if (v.Ticket.ParkedTime == parkedTime)
                {
                    result.Add(v);
                }
            }
            return result;
        }
    }
}
