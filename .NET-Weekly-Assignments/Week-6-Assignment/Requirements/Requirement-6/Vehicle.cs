namespace Requirement_6
{
    internal class Vehicle
    {
        // Private fields to store Vehicle details
        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;

        // Public property to get/set registration number
        public string RegistrationNo
        {
            get { return _registrationNo; }
            set { _registrationNo = value; }
        }

        // Public property to get/set vehicle name
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Public property to get/set vehicle type
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        // Public property to get/set vehicle weight
        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        // Default constructor 
        public Vehicle()
        {
            _registrationNo = string.Empty;
            _name = string.Empty;
            _type = string.Empty;
            _weight = 0.0;
        }

        // Parameterized constructor 
        public Vehicle(string? registrationNo, string? name, string? type, double weight)
        {
            _registrationNo = registrationNo;
            _name = name;
            _type = type;
            _weight = weight;
        }

        // Create Vehicle
        public static Vehicle CreateVehicle(string detail)
        {
            // Split the input string 
            string[] data = detail.Split(',');

            // Vehicle details
            string registrationNo = data[0];
            string name = data[1];
            string type = data[2];
            double weight = double.Parse(data[3]);

            // Create and return Vehicle object
            return new Vehicle(registrationNo, name, type, weight);
        }

        // Type-wise count of vehicles
        public static SortedDictionary<string, int>TypeWiseCount(List<Vehicle> vehicleList)
        {
            SortedDictionary<string, int> result =new SortedDictionary<string, int>();
            foreach (Vehicle v in vehicleList)
            {
                if (result.ContainsKey(v.Type))
                    result[v.Type]++;
                else
                    result[v.Type] = 1;
            }
            return result;
        }
    }
}