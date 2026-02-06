using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requirement1
{
    public class Vehcile
    {
        public string _registrationNo { get; set; }
        public string _name { get; set; }
        public string _type { get; set; }
        public double _weight { get; set; }

        public Ticket? _ticket { get; set; }

        public Vehcile(string _registrationNo, string _name, string _type, double _weight)
        {
            this._registrationNo = _registrationNo;
            this._name = _name;
            this._type = _type;
            this._weight = _weight;
            this._ticket = null;

        }
        public override string ToString()
        {
            string ticketinfo;

            if (_ticket == null)
            {
                ticketinfo = "No ticket is assigned";
            }
            else
            {
                ticketinfo =
                    $"TicketNo          ={_ticket._ticketNo}\n" +
                    $"ParkTime          ={_ticket._parkedTime}\n" +
                    $"Cost              ={_ticket._cost}";
            }

            return

                $"----------------\n" +
                $"Registration No = {_registrationNo}\n" +
                $"Name            = {_name}\n" +
                $"Type            = {_type}\n" +
                $"Weight          = {_weight} kg\n" +
                $"{ticketinfo}";
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Vehcile other = (Vehcile)obj;
            return this._registrationNo == other._registrationNo & this._name == other._name;

        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            throw new System.NotImplementedException();
            return base.GetHashCode();
        }




    }
}