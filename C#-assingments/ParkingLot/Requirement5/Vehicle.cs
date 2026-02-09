using System;

namespace Requirement5
{
    public class Vehicle : IComparable<Vehicle>
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

        public static Vehicle CreateVehicle(string detail)
        {
            string[] parts = detail.Split(',');
            return new Vehicle(parts[0], parts[1], parts[2], double.Parse(parts[3]), 
                new Ticket(parts[4], DateTime.ParseExact(parts[5], "dd-MM-yyyy HH:mm:ss", null), double.Parse(parts[6])));
        }

        public int CompareTo(Vehicle other)
        {
            if (other == null) return 1;
            return _weight.CompareTo(other._weight);
        }
    }
}
