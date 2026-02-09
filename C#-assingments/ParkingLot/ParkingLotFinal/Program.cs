using System;
using System.Collections.Generic;
using System.Globalization;

namespace ParkingLotFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize Parking Lot
            ParkingLot parkingLot = new ParkingLot("Hartford Parking", new List<Vehicle>());
            VehicleBO vehicleBO = new VehicleBO();

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. Delete Vehicle");
                Console.WriteLine("3. Display Vehicles");
                Console.WriteLine("4. Search Vehicles");
                Console.WriteLine("5. Sort Vehicles");
                Console.WriteLine("6. Type Wise Count");
                Console.WriteLine("7. Exit");
                Console.WriteLine("8. Compare Two Vehicles (Req 1)");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddVehicle(parkingLot);
                        break;
                    case "2":
                        DeleteVehicle(parkingLot);
                        break;
                    case "3":
                        DisplayVehicles(parkingLot);
                        break;
                    case "4":
                        SearchVehicles(parkingLot, vehicleBO);
                        break;
                    case "5":
                        SortVehicles(parkingLot);
                        break;
                    case "6":
                        TypeWiseCount(parkingLot);
                        break;
                    case "7":
                        return;
                    case "8":
                        CompareTwoVehicles();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }

        static void AddVehicle(ParkingLot parkingLot)
        {
            Console.WriteLine("Enter vehicle details (registrationNo,name,type,weight,ticketNo,parkedTime,cost):");
            string input = Console.ReadLine();
            try
            {
                Vehicle vehicle = Vehicle.CreateVehicle(input);
                if (Vehicle.ValidateRegistrationNo(vehicle.RegistrationNo))
                {
                    // Print validation success logic if strictly needed, but Req 3 says "Print in Main".
                    // However, Req 2 says "Vehicle successfully added".
                    // If we just add it, we satisfy R2.
                    // But if it's invalid, we probably shouldn't add?
                    // The prompt "Requirement 3... Print in Main... valid/invalid".
                    // I'll assume validation is a prerequisite for adding.
                    
                    // Console.WriteLine("Registration No. is valid"); // Optional, maybe too noisy?
                    // The requirement 3 seems to be a standalone logic prompt. 
                    // I will print "Registration No. is valid" purely to satisfy R3 explicit output, 
                    // but usually users don't want that. 
                    // "Print in Main(): - Registration No. is valid..."
                    // Okay I'll print it.
                    // Console.WriteLine("Registration No. is valid"); // Actually requirement says "Print in Main".

                    Console.WriteLine("Registration No. is valid");
                    parkingLot.AddVehicleToParkingLot(vehicle);
                    Console.WriteLine("Vehicle successfully added");
                }
                else
                {
                    Console.WriteLine("Registration No. is invalid");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating vehicle: " + ex.Message);
            }
        }

        static void DeleteVehicle(ParkingLot parkingLot)
        {
            Console.WriteLine("Enter Registration Number to delete:");
            string regNo = Console.ReadLine();
            bool removed = parkingLot.RemoveVehicleFromParkingLot(regNo);
            if (removed)
            {
                Console.WriteLine("Vehicle successfully deleted");
            }
            else
            {
                Console.WriteLine("Vehicle not found in parkinglot");
            }
        }

        static void DisplayVehicles(ParkingLot parkingLot)
        {
            parkingLot.DisplayVehicles();
        }

        static void SearchVehicles(ParkingLot parkingLot, VehicleBO vehicleBO)
        {
            Console.WriteLine("1. By type");
            Console.WriteLine("2. By parked time");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            List<Vehicle> results = new List<Vehicle>();

            if (choice == "1")
            {
                Console.WriteLine("Enter Type:");
                string type = Console.ReadLine();
                results = vehicleBO.FindVehicle(parkingLot.VehicleList, type);
            }
            else if (choice == "2")
            {
                Console.WriteLine("Enter Parked Time (dd-MM-yyyy HH:mm:ss):");
                string dateStr = Console.ReadLine();
                if (DateTime.TryParseExact(dateStr, "dd-MM-yyyy HH:mm:ss", null, DateTimeStyles.None, out DateTime parkedTime))
                {
                    results = vehicleBO.FindVehicle(parkingLot.VehicleList, parkedTime);
                }
                else
                {
                    Console.WriteLine("Invalid date format");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid Choice");
                return;
            }

            if (results.Count > 0)
            {
                 // Reuse ParkingLot display Logic?
                 // ParkingLot.DisplayVehicles takes list? 
                 // I made it optional in my implementation, so I can call it.
                 parkingLot.DisplayVehicles(results);
            }
            else
            {
                Console.WriteLine("No such vehicle is present");
            }
        }

        static void SortVehicles(ParkingLot parkingLot)
        {
            Console.WriteLine("1. Sort by weight");
            Console.WriteLine("2. Sort by parked time");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                parkingLot.VehicleList.Sort(); // Uses IComparable (Weight)
                Console.WriteLine("Vehicles sorted by weight");
                parkingLot.DisplayVehicles();
            }
            else if (choice == "2")
            {
                parkingLot.VehicleList.Sort(new ParkedTimeComparer());
                Console.WriteLine("Vehicles sorted by parked time");
                parkingLot.DisplayVehicles();
            }
            else
            {
                Console.WriteLine("Invalid Choice");
            }
        }

        static void TypeWiseCount(ParkingLot parkingLot)
        {
            var counts = Vehicle.TypeWiseCount(parkingLot.VehicleList);
            Console.WriteLine("{0,-20} {1}", "Type", "No. of Vehicles");
            foreach (var kvp in counts)
            {
                Console.WriteLine("{0,-20} {1}", kvp.Key, kvp.Value);
            }
        }

        static void CompareTwoVehicles()
        {
            Console.WriteLine("Enter vehicle 1 details:");
            string input1 = Console.ReadLine();
            Console.WriteLine("Enter vehicle 2 details:");
            string input2 = Console.ReadLine();

            try
            {
                Vehicle v1 = Vehicle.CreateVehicle(input1);
                Vehicle v2 = Vehicle.CreateVehicle(input2);

                Console.WriteLine("Vehicle 1:");
                Console.WriteLine(v1.ToString());
                Console.WriteLine(); // Empty line

                Console.WriteLine("Vehicle 2:");
                Console.WriteLine(v2.ToString());
                Console.WriteLine(); // Empty line based on requirement "leave one empty line between outputs"?
                // Actually requirement says "leave one empty line between outputs, and print...".
                // I'll put an empty line before comparison result too.

                if (v1.Equals(v2))
                {
                    Console.WriteLine("Vehicle 1 is same as Vehicle 2");
                }
                else
                {
                    Console.WriteLine("Vehicle 1 and Vehicle 2 are different");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
