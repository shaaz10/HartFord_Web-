using System;

namespace Requirement1
{
    class Program
    {
        static void Main(string[] args)
        {

            // This is 6th Question
            Vehcile v1 = new Vehcile("TS09AB1234", "Honda", "Car", 1200);
            Vehcile v2 = new Vehcile("TS09AB1234", "Honda", "Car", 1300);
            System.Console.WriteLine();
            System.Console.WriteLine("Vehicle 1");
            System.Console.WriteLine();
            System.Console.WriteLine(v1);
            System.Console.WriteLine();
            System.Console.WriteLine("Vehicle 2");
            System.Console.WriteLine();

            System.Console.WriteLine();
            Console.WriteLine(v1.Equals(v2));
            if(v1.Equals(v2)){
                System.Console.WriteLine("Vehicle 1 is same as Vehicle 2");
                System.Console.WriteLine();
            }
            else{
                System.Console.WriteLine("Vehicle 1 and Vehicle 2 are different");
                System.Console.WriteLine();
            }
            





        }
    }
}
