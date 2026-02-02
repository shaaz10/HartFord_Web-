using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Exercise 7: Arrays ===\n");
        
        Console.WriteLine("--- 1D Array: Student Marks ---");
        int[] marks = new int[5];
        
        Console.WriteLine("Enter marks for 5 students:");
        for (int i = 0; i < marks.Length; i++)
        {
            Console.Write($"Student {i + 1}: ");
            marks[i] = int.Parse(Console.ReadLine());
        }
        
        Console.WriteLine("\n--- Marks Summary ---");
        int sum = 0;
        int highest = marks[0];
        int lowest = marks[0];
        
        for (int i = 0; i < marks.Length; i++)
        {
            sum += marks[i];
            if (marks[i] > highest) highest = marks[i];
            if (marks[i] < lowest) lowest = marks[i];
        }
        
        double average = (double)sum / marks.Length;
        
        Console.WriteLine($"Total Marks: {sum}");
        Console.WriteLine($"Average: {average:F2}");
        Console.WriteLine($"Highest: {highest}");
        Console.WriteLine($"Lowest: {lowest}");
        
        Console.WriteLine("\n--- 2D Array: Simple Matrix ---");
        int[,] matrix = new int[3, 3];
        
        Console.WriteLine("Enter 9 numbers for 3x3 matrix:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"[{i},{j}]: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
        
        Console.WriteLine("\n--- Matrix Display ---");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
