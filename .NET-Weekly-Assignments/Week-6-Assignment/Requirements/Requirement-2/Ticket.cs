namespace Requirement_2
{
    // b) Create a Class Ticket
    internal class Ticket
    {
        // Private field to store ticket details
        private string _ticketNo;
        private DateTime _parkedTime;
        private double _cost;

        // Public property to get/set ticket number
        public string TicketNo
        {
            get { return _ticketNo; }
            set { _ticketNo = value; }
        }

        // Public property to get/set parked time
        public DateTime ParkedTime
        {
            get { return _parkedTime; }
            set { _parkedTime = value; }
        }

        // Public property to get/set parking cost
        public double Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        // Parameterized constructor to initialize ticket details
        public Ticket(string ticketNo, DateTime parkedTime, Double cost)
        {
            _ticketNo = ticketNo;
            _parkedTime = parkedTime;
            _cost = cost;
        }
    }
}