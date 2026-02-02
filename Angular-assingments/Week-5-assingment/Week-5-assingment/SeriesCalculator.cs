using System;

namespace Week_5_assignment
{
    public class SeriesCalculator
    {
        public void PrintSeries(int n)
        {
            int i, term;

            for (i = 0; i < n; i++)
            {
                term = i * (i + 1) * (i + 2);
                Console.Write(term);

                if (i < n - 1)
                    Console.Write(", ");
            }
        }
    }
}
