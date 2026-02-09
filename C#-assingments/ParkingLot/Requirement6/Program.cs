using System;
using System.Collections.Generic;

namespace Requirement6
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot parkingLot = new ParkingLot("Requirement6 Lot", new List<Vehicle>());

            while (true)
            {
                Console.WriteLine("1. Add Vehicle\n2. Delete Vehicle\n3. Display Vehicles\n4. Type Wise Count\n5. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter vehicle details (registrationNo,name,type,weight,ticketNo,parkedTime,cost):");
                        string input = Console.ReadLine();
                        try
                        {
                            parkingLot.AddVehicleToParkingLot(Vehicle.CreateVehicle(input));
                            Console.WriteLine("Vehicle successfully added");
                        }
                        catch
                        {
                            Console.WriteLine("Error parsing vehicle");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Enter Registration Number to delete:");
                        string regNo = Console.ReadLine();
                        if (parkingLot.RemoveVehicleFromParkingLot(regNo))
                            Console.WriteLine("Vehicle successfully deleted");
                        else
                            Console.WriteLine("Vehicle not found in parkinglot");
                        break;
                    case "3":
                        parkingLot.DisplayVehicles();
                        break;
                    case "4":
                        var counts = Vehicle.TypeWiseCount(parkingLot.VehicleList);
                        Console.WriteLine("{0,-20} {1}", "Type", "No. of Vehicles");
                        foreach (var kvp in counts)
                        {
                            Console.WriteLine("{0,-20} {1}", kvp.Key, kvp.Value);
                        }
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}
