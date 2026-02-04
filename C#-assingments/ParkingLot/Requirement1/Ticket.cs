using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requirement1
{
    public class Ticket
    {
        public int _ticketNo { get; set; }
        public DateTime _parkedTime { get; set; }
        public double _cost { get; set; }

        public Ticket(int ticketNo)
        {
            _ticketNo=ticketNo;
            _parkedTime=DateTime.Now;
            _cost=0;
        }
    }
}