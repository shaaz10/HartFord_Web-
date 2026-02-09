using System;
using System.Collections.Generic;

namespace Requirement2
{
    public class ParkingLot
    {
        private string _name;
        private List<Vehcile> _vehcileList;
        private int _nextTicketNo;

        public ParkingLot(string name, List<Vehcile>? vehcileList = null, int startTicketNo = 100)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _vehcileList = vehcileList ?? new List<Vehcile>();
            _nextTicketNo = startTicketNo - 1; // first issued ticket will be startTicketNo
        }

        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException(nameof(value));
        }

        public IReadOnlyList<Vehcile> Vehicles => _vehcileList.AsReadOnly();

        public bool AddVehicle(Vehcile v)
        {
            if (v == null) return false;
            if (GetVehicle(v._registrationNo) != null) return false; // duplicate registration
            _vehcileList.Add(v);
            return true;
        }

        public bool RemoveVehicle(string registrationNo)
        {
            var v = GetVehicle(registrationNo);
            if (v == null) return false;
            return _vehcileList.Remove(v);
        }

        public Vehcile? GetVehicle(string registrationNo)
        {
            if (string.IsNullOrWhiteSpace(registrationNo)) return null;
            foreach (var v in _vehcileList)
            {
                if (string.Equals(v._registrationNo, registrationNo, StringComparison.OrdinalIgnoreCase))
                    return v;
            }
            return null;
        }

        public Ticket? IssueTicket(string registrationNo)
        {
            var v = GetVehicle(registrationNo);
            if (v == null) return null;
            if (v._ticket != null) return v._ticket; // already has ticket
            var ticket = new Ticket(++_nextTicketNo);
            v._ticket = ticket;
            return ticket;
        }

        public override string ToString()
        {
            var info = $"ParkingLot: {_name}\nTotal vehicles: {_vehcileList.Count}\n";
            foreach (var v in _vehcileList)
            {
                info += v + "\n";
            }
            return info;
        }
    }
}