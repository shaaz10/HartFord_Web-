using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ParkingLotFinal
{
    public class Vehicle : IComparable<Vehicle>
    {
        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;
        private Ticket _ticket;

        public string RegistrationNo
        {
            get { return _registrationNo; }
            set { _registrationNo = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public Ticket Ticket
        {
            get { return _ticket; }
            set { _ticket = value; }
        }

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

        public int CompareTo(Vehicle other)
        {
            if (other == null) return 1;
            return _weight.CompareTo(other._weight);
        }

        public static Vehicle CreateVehicle(string detail)
        {
            // detail format: registrationNo,name,type,weight,ticketNo,parkedTime,cost
            string[] parts = detail.Split(',');
            if (parts.Length != 7)
            {
                throw new ArgumentException("Invalid vehicle detail format");
            }

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

        public static bool ValidateRegistrationNo(string registrationNo)
        {
            // First part: 2 uppercase letters
            // Second part: 1–2 digits
            // Third part: 0–2 uppercase letters (optional)
            // Fourth part: 1–4 digits
            // Parts separated by space

            string pattern = @"^[A-Z]{2}\s\d{1,2}\s([A-Z]{0,2}\s)?\d{1,4}$";
            // The prompt example: "TS 01 K 1562" (Third part is 1 letter, followed by space, fourth part 4 digits)
            // "TS 02 9651" (Third part empty? prompts says "0-2 uppercase letters (optional)". If 0 letters, is the space still there?
            // "TS 02 9651" looks like: Part1=TS, Part2=02, Part3=(empty), Part4=9651.
            // The regex above assumes if Part3 is present, it's followed by space. If Part3 is empty, no extra space before Part4?
            // "TS 02 9651" has ONE space between 02 and 9651?
            // The constraint says "Parts separated by space".
            // If Part 3 is optional (0 length), does it consume a space?
            // Usually optional parts in registration imply:
            // "TS 01 K 1562" -> "XX 00 X 0000"
            // "TS 02 9651" -> "XX 00 0000"
            // So structure is: [2 Upper] [Space] [1-2 Digits] [Space] ([0-2 Upper] [Space])? [1-4 Digits]
            
            // Let's refine the regex for explicit behavior.
            // Part 1: ^[A-Z]{2}
            // Separator: \s
            // Part 2: \d{1,2}
            // Separator: \s
            // Part 3 (Optional): ([A-Z]{1,2}\s)?  <- If present, must be 1-2 upper followed by space.
            // Part 4: \d{1,4}$

            // Wait, "0-2 uppercase letters". If 0 letters, checking "TS 02 9651".
            // Structure: "TS" (space) "02" (space) "9651".
            // Structure: "TS" (space) "01" (space) "K" (space) "1562".
            // So if Part 3 exists, it's separated from Part 2 and Part 4 by spaces.
            // If Part 3 does NOT exist, Part 2 is separated from Part 4 by A space.
            
            return Regex.IsMatch(registrationNo, pattern);
        }

        public static SortedDictionary<string, int> TypeWiseCount(List<Vehicle> vehicleList)
        {
            SortedDictionary<string, int> counts = new SortedDictionary<string, int>();
            foreach (var v in vehicleList)
            {
                if (counts.ContainsKey(v.Type))
                    counts[v.Type]++;
                else
                    counts[v.Type] = 1;
            }
            return counts;
        }
    }
}
