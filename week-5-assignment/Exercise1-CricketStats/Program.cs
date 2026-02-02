using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Dhoni Cricket Statistics Pattern Prediction ===\n");
        
        // Dhoni's Test batting statistics pattern
        // Series: 0, 6, 24, 60, 120, 210, 336, ...
        // Pattern: Each number = n * (n+1) * (n+2) / 2 where n is series number
        
        Console.WriteLine("Enter the series number (N) to predict Dhoni's runs:");
        
        if (int.TryParse(Console.ReadLine(), out int seriesNumber))
        {
            if (seriesNumber < 0)
            {
                Console.WriteLine("Series number cannot be negative.");
                return;
            }
            
            long predictedRuns = CalculatePredictedRuns(seriesNumber);
            Console.WriteLine($"\nFor series {seriesNumber}: Predicted runs = {predictedRuns}");
            
            // Display pattern for reference
            Console.WriteLine("\n=== Pattern Reference ===");
            for (int i = 0; i <= Math.Min(seriesNumber, 7); i++)
            {
                Console.WriteLine($"Series {i}: {CalculatePredictedRuns(i)} runs");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
    
    static long CalculatePredictedRuns(int n)
    {
        // Pattern formula: n * (n+1) * (n+2) / 2
        // This represents triangular numbers in a sequence
        return (long)n * (n + 1) * (n + 2) / 2;
    }
}
