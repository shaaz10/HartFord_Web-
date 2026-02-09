using System;

namespace Requirement1
{
    public class Vehicle
    {
        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;
        private Ticket _ticket;

        public string RegistrationNo { get { return _registrationNo; } set { _registrationNo = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public double Weight { get { return _weight; } set { _weight = value; } }
        public Ticket Ticket { get { return _ticket; } set { _ticket = value; } }

        public Vehicle(string registrationNo, string name, string type, double weight, Ticket ticket)
        {
            _registrationNo = registrationNo;
            _name = name;
            _type = type;
            _weight = weight;
            _ticket = ticket;
        }

        public override string ToString()
        {
            return string.Format("Registration No:{0}\nName:{1}\nType:{2}\nWeight:{3:F1}\nTicket No:{4}",
                _registrationNo, _name, _type, _weight, _ticket.TicketNo);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Vehicle other = (Vehicle)obj;
            return string.Equals(_registrationNo, other._registrationNo, StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(_name, other._name, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return (_registrationNo.ToLower() + _name.ToLower()).GetHashCode();
        }

        public static Vehicle CreateVehicle(string detail)
        {
            string[] parts = detail.Split(',');
            // registrationNo,name,type,weight,ticketNo,parkedTime,cost
            string regNo = parts[0];
            string name = parts[1];
            string type = parts[2];
            double weight = double.Parse(parts[3]);
            string ticketNo = parts[4];
            DateTime parkedTime = DateTime.ParseExact(parts[5], "dd-MM-yyyy HH:mm:ss", null);
            double cost = double.Parse(parts[6]);

            Ticket ticket = new Ticket(ticketNo, parkedTime, cost);
            return new Vehicle(regNo, name, type, weight, ticket);
        }
    }
}
