namespace Requirement_1
{
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
        public Ticket(string ticketNo, DateTime parkedTime, double cost)
        {
            _ticketNo = ticketNo;
            _parkedTime = parkedTime;
            _cost = cost;
        }

        // Override ToString() to display ticket number in required format
        public override string ToString()
        {
            return $" {_ticketNo}";
        }
    }
}