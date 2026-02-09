using System;


namespace Requirement2
{
    class Program
    {
        static void Main(string[] args)
        {

            // This is 6th Question
            Vehcile v1 = new Vehcile("TS09AB1234", "Honda", "Car", 1200);
            Vehcile v2 = new Vehcile("TS09AC1234", "Suzuki", "Car", 1300);
            v1._ticket=new Ticket(101);
            v2._ticket=new Ticket(102);
            Console.WriteLine();
            // Print header in required format
            Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7} {4}", "Registration No", "Name", "Type", "Weight", "Ticket No");
            // Print vehicle rows matching the PDF format: 1 digit after decimal for weight
            Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7:0.0} {4}", v1._registrationNo, v1._name, v1._type, v1._weight, v1._ticket?._ticketNo.ToString() ?? "");
            Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7:0.0} {4}", v2._registrationNo, v2._name, v2._type, v2._weight, v2._ticket?._ticketNo.ToString() ?? "");

            Console.WriteLine();
            Console.WriteLine(v1.Equals(v2));
            if (v1.Equals(v2))
            {
                Console.WriteLine("Vehicle 1 is same as Vehicle 2");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Vehicle 1 and Vehicle 2 are different");
                Console.WriteLine();
            }
            





        }
    }
}
