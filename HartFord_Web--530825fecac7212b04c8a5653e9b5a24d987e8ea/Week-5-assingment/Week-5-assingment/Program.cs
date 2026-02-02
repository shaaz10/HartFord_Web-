using System;

namespace Week_5_assignment   // ✅ THIS WAS MISSING
{
    class Program
    {
        static void Main()
        {
            int n;

            Console.WriteLine("Enter number of matches (N):");
            n = Convert.ToInt32(Console.ReadLine());

            SeriesCalculator sc = new SeriesCalculator();
            sc.PrintSeries(n);

            Console.ReadLine();
        }
    }
}
