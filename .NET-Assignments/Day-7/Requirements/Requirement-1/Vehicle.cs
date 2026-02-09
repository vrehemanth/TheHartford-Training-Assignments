namespace Requirement_1
{
    // 1) Create a Vehicle Class 
    internal class Vehicle
    {
        // Private fields to store Vehicle details
        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;
        private Ticket _ticket;

        // 3) Create / Generate appropriate Properties

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

        // 4) Parameterized constructor to initialize all vehicle attributes
        public Vehicle(string? registrationNo, string? name, string? type, double weight, Ticket ticket)
        {
            _registrationNo = registrationNo;
            _name = name;
            _type = type;
            _weight = weight;
            _ticket = ticket;
        }

        // 5) Override ToString() to display vehicle details in required format
        public override string ToString()
        {
            return $"Registration No: {_registrationNo}\n" +
                   $"Name: {_name}\n" +
                   $"Type: {_type}\n" +
                   $"Weight: {_weight}\n" +
                   $"Ticket Details: {_ticket}";
        }

        // 6) Override Equals() to compare two Vehicle objects
        public override bool Equals(object obj)
        {
            if (obj == null || obj is not Vehicle)
                return false;

            Vehicle other = (Vehicle)obj;

            return string.Equals(this._registrationNo, other._registrationNo,StringComparison.OrdinalIgnoreCase)
                && string.Equals(this._name, other._name,StringComparison.OrdinalIgnoreCase);
        }

        // Override GetHashCode()
        public override int GetHashCode()
        {
            return (_registrationNo.ToLower() + _name.ToLower()).GetHashCode();
        }
    }
}