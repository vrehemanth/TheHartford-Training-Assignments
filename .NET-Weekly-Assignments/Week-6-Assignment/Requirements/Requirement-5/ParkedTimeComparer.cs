using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_5
{
    internal class ParkedTimeComparer : IComparer<Vehicle>
    {
        // Compare vehicles based on ParkedTime
        public int Compare(Vehicle x, Vehicle y)
        {
            if (x == null || y == null)
                return 0;
            // All parkedTime values are unique
            return x.Ticket.ParkedTime.CompareTo(y.Ticket.ParkedTime);
        }
    }
}
