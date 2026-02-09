using System;
using System.Text.RegularExpressions;

namespace Requirement3
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

        public static Vehicle CreateVehicle(string detail)
        {
            string[] parts = detail.Split(',');
            return new Vehicle(parts[0], parts[1], parts[2], double.Parse(parts[3]), 
                new Ticket(parts[4], DateTime.ParseExact(parts[5], "dd-MM-yyyy HH:mm:ss", null), double.Parse(parts[6])));
        }

        public static bool ValidateRegistrationNo(string registrationNo)
        {
            // TS 01 K 1562
            // ^[A-Z]{2}\s\d{1,2}\s([A-Z]{0,2}\s)?\d{1,4}$
            string pattern = @"^[A-Z]{2}\s\d{1,2}\s([A-Z]{1,2}\s)?\d{1,4}$";
            // Wait, previous regex logic was slightly ambiguous on space. I'll stick to robust pattern.
            // Requirement: "3rd part: 0-2 uppercase letters (optional)".
            // IF it is 0 letters, is the space present? "TS 02 9651" is valid.
            // TS (space) 02 (space) 9651.
            // TS (space) 01 (space) K (space) 1562.
            // My previous pattern: `([A-Z]{0,2}\s)?`
            // If 0 chars, then `\s`? `( \s)?` NO.
            // If 0 chars, the group matches nothing?
            // "TS 02 9651" -> Part 1=TS, Part 2=02, Part 4=9651. Space between 2 and 4? Yes.
            // So structure is: P1 + Space + P2 + Space + (P3 + Space)? + P4.
            // Regex: ^[A-Z]{2}\s\d{1,2}\s([A-Z]{1,2}\s)?\d{1,4}$
            return Regex.IsMatch(registrationNo, pattern);
        }
    }
}
