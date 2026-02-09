using System;

namespace Requirement1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter vehicle 1 details:");
            string input1 = Console.ReadLine();
            Console.WriteLine("Enter vehicle 2 details:");
            string input2 = Console.ReadLine();

            Vehicle v1 = Vehicle.CreateVehicle(input1);
            Vehicle v2 = Vehicle.CreateVehicle(input2);

            Console.WriteLine("Vehicle 1:");
            Console.WriteLine(v1.ToString());
            Console.WriteLine();

            Console.WriteLine("Vehicle 2:");
            Console.WriteLine(v2.ToString());
            Console.WriteLine();

            if (v1.Equals(v2))
                Console.WriteLine("Vehicle 1 is same as Vehicle 2");
            else
                Console.WriteLine("Vehicle 1 and Vehicle 2 are different");
        }
    }
}
