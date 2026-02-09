using System.Collections.Generic;

namespace Requirement5
{
    public class ParkedTimeComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle x, Vehicle y)
        {
            if (x == null || x.Ticket == null) return -1;
            if (y == null || y.Ticket == null) return 1;
            return x.Ticket.ParkedTime.CompareTo(y.Ticket.ParkedTime);
        }
    }
}
