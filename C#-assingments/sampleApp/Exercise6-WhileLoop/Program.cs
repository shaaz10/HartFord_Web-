using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Exercise 6: Loops - While & Do-While ===\n");
        
        Console.WriteLine("--- While Loop: Countdown ---");
        Console.Write("Enter a number to countdown from: ");
        int count = int.Parse(Console.ReadLine());
        
        while (count > 0)
        {
            Console.WriteLine(count);
            count--;
        }
        Console.WriteLine("Blastoff!");
        
        Console.WriteLine("\n--- Do-While Loop: User Input Validation ---");
        int choice;
        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Print Hello");
            Console.WriteLine("2. Print Goodbye");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice (1-3): ");
            choice = int.Parse(Console.ReadLine());
            
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Hello!");
                    break;
                case 2:
                    Console.WriteLine("Goodbye!");
                    break;
                case 3:
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (choice != 3);
        
        Console.WriteLine("\n--- While Loop: Sum Until Negative ---");
        int total = 0;
        int input;
        Console.WriteLine("Enter numbers (negative number to stop):");
        do
        {
            Console.Write("Enter a number: ");
            input = int.Parse(Console.ReadLine());
            if (input >= 0)
                total += input;
        } while (input >= 0);
        
        Console.WriteLine($"Total sum: {total}");
    }
}
