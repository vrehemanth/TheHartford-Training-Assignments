namespace Requirement_2
{
    // a) Create a Class Vehicle 
    internal class Vehicle
    {
        // Private fields to store Vehicle details
        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;
        private Ticket _ticket;

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

        // Public property to get/set ticket details
        public Ticket Ticket
        {
            get { return _ticket; }
            set { _ticket = value; }
        }

        // Parameterized constructor to initialize all vehicle attributes
        public Vehicle(string? registrationNo, string? name, string? type, Double weight, Ticket ticket)
        {
            _registrationNo = registrationNo;
            _name = name;
            _type = type;
            _weight = weight;
            _ticket = ticket;
        }

        // d) Create Vehicle
        public static Vehicle CreateVehicle(string detail)
        {
            // Split the input string 
            string[] data = detail.Split(',');

            // Vehicle details
            string registrationNo = data[0];
            string name = data[1];
            string type = data[2];
            Double.TryParse(data[3],out Double weight);

            // Ticket details
            string ticketNo = data[4];
            DateTime parkedTime = DateTime.Parse(data[5]);
            Double.TryParse(data[6],out Double cost);

            // Create Ticket object
            Ticket ticket = new Ticket(ticketNo, parkedTime, cost);

            // Create and return Vehicle object
            return new Vehicle(registrationNo, name, type, weight, ticket);
        }
    }
}