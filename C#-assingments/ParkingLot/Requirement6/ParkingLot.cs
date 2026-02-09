using System;
using System.Collections.Generic;
using System.Linq;

namespace Requirement6
{
    public class ParkingLot
    {
        private string _name;
        private List<Vehicle> _vehicleList;

        public ParkingLot(string name, List<Vehicle> vehicleList)
        {
            _name = name;
            _vehicleList = vehicleList;
        }

        public List<Vehicle> VehicleList { get { return _vehicleList; } }

        public void AddVehicleToParkingLot(Vehicle vehicle)
        {
            _vehicleList.Add(vehicle);
        }

        public bool RemoveVehicleFromParkingLot(string registrationNo)
        {
            var vehicle = _vehicleList.FirstOrDefault(v => v.RegistrationNo.Equals(registrationNo, StringComparison.OrdinalIgnoreCase));
            if (vehicle != null)
            {
                _vehicleList.Remove(vehicle);
                return true;
            }
            return false;
        }

        public void DisplayVehicles()
        {
            if (_vehicleList.Count == 0)
            {
                Console.WriteLine("No vehicles to show");
                return;
            }

            Console.WriteLine("{0,-20} {1,-15} {2,-15} {3,-10} {4,-15}", "Registration No", "Name", "Type", "Weight", "Ticket No");
            foreach (var v in _vehicleList)
            {
                Console.WriteLine("{0,-20} {1,-15} {2,-15} {3,-10:F1} {4,-15}", 
                    v.RegistrationNo, v.Name, v.Type, v.Weight, v.Ticket.TicketNo);
            }
        }
    }
}
