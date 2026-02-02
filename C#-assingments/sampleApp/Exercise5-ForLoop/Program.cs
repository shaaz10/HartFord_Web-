using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Exercise 5: Loops - For Loop ===\n");
        
        Console.WriteLine("--- Multiplication Table ---");
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        
        Console.WriteLine($"\nMultiplication table of {number}:");
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{number} × {i} = {number * i}");
        }
        
        Console.WriteLine("\n--- Pattern: Number Triangle ---");
        Console.Write("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine());
        
        Console.WriteLine();
        for (int i = 1; i <= rows; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(j + " ");
            }
            Console.WriteLine();
        }
        
        Console.WriteLine("\n--- Sum of First N Numbers ---");
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());
        
        int sum = 0;
        for (int i = 1; i <= n; i++)
        {
            sum += i;
        }
        Console.WriteLine($"Sum of first {n} numbers: {sum}");
    }
}
