using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLotFinal
{
    public class VehicleBO
    {
        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList, string type)
        {
            return vehicleList.Where(v => v.Type.Equals(type, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList, DateTime parkedTime)
        {
            // Assuming exact parked time match or just compare date?
            // "Sort by parkedTime (all times unique)" suggests strict comparison.
            // Using exact match.
            return vehicleList.Where(v => v.Ticket.ParkedTime == parkedTime).ToList();
        }
    }
}
