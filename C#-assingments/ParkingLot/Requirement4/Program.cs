using System;
using System.Collections.Generic;
using System.Globalization;

namespace Requirement4
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot parkingLot = new ParkingLot("Requirement4 Lot", new List<Vehicle>());
            VehicleBO vehicleBO = new VehicleBO();

            while (true)
            {
                Console.WriteLine("1. Add Vehicle\n2. Delete Vehicle\n3. Display Vehicles\n4. Search Vehicles\n5. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter vehicle details (registrationNo,name,type,weight,ticketNo,parkedTime,cost):");
                        string input = Console.ReadLine();
                        try
                        {
                            Vehicle vehicle = Vehicle.CreateVehicle(input);
                            if (Vehicle.ValidateRegistrationNo(vehicle.RegistrationNo))
                            {
                                Console.WriteLine("Registration No. is valid");
                                parkingLot.AddVehicleToParkingLot(vehicle);
                                Console.WriteLine("Vehicle successfully added");
                            }
                            else
                            {
                                Console.WriteLine("Registration No. is invalid");
                            }
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
                        Console.WriteLine("1. By type\n2. By parked time");
                        Console.Write("Enter your choice: ");
                        string searchChoice = Console.ReadLine();
                        List<Vehicle> results = new List<Vehicle>();
                        if (searchChoice == "1")
                        {
                            Console.WriteLine("Enter Type:");
                            string type = Console.ReadLine();
                            results = vehicleBO.FindVehicle(parkingLot.VehicleList, type);
                        }
                        else if (searchChoice == "2")
                        {
                            Console.WriteLine("Enter Parked Time (dd-MM-yyyy HH:mm:ss):");
                            if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy HH:mm:ss", null, DateTimeStyles.None, out DateTime dt))
                                results = vehicleBO.FindVehicle(parkingLot.VehicleList, dt);
                            else
                            {
                                Console.WriteLine("Invalid date format");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Choice");
                            break;
                        }

                        if (results.Count > 0)
                            parkingLot.DisplayVehicles(results);
                        else
                            Console.WriteLine("No such vehicle is present");
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
