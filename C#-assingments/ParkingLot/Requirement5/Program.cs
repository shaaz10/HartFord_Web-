using System;
using System.Collections.Generic;

namespace Requirement5
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot parkingLot = new ParkingLot("Requirement5 Lot", new List<Vehicle>());

            while (true)
            {
                Console.WriteLine("1. Add Vehicle\n2. Delete Vehicle\n3. Display Vehicles\n4. Sort Vehicles\n5. Exit");
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
                        Console.WriteLine("1. Sort by weight\n2. Sort by parked time");
                        Console.Write("Enter your choice: ");
                        string sortChoice = Console.ReadLine();
                        if (sortChoice == "1")
                        {
                            parkingLot.VehicleList.Sort(); // Uses IComparable implementation (Weight)
                            Console.WriteLine("Vehicles sorted by weight");
                            parkingLot.DisplayVehicles();
                        }
                        else if (sortChoice == "2")
                        {
                            parkingLot.VehicleList.Sort(new ParkedTimeComparer());
                            Console.WriteLine("Vehicles sorted by parked time");
                            parkingLot.DisplayVehicles();
                        }
                        else
                        {
                            Console.WriteLine("Invalid Choice");
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
