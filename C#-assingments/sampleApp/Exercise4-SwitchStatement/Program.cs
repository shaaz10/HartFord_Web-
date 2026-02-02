using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Exercise 4: Switch Statement ===\n");
        
        Console.WriteLine("Select a fruit (1-5):");
        Console.WriteLine("1. Apple");
        Console.WriteLine("2. Banana");
        Console.WriteLine("3. Orange");
        Console.WriteLine("4. Mango");
        Console.WriteLine("5. Grapes");
        Console.Write("Enter your choice: ");
        
        int choice = int.Parse(Console.ReadLine());
        
        Console.WriteLine("\n--- Your Selection ---");
        switch (choice)
        {
            case 1:
                Console.WriteLine("You selected Apple - Rich in fiber and vitamin C");
                break;
            case 2:
                Console.WriteLine("You selected Banana - Good source of potassium");
                break;
            case 3:
                Console.WriteLine("You selected Orange - High in vitamin C");
                break;
            case 4:
                Console.WriteLine("You selected Mango - King of fruits, sweet and delicious");
                break;
            case 5:
                Console.WriteLine("You selected Grapes - Small but nutritious");
                break;
            default:
                Console.WriteLine("Invalid choice! Please select 1-5.");
                break;
        }
        
        Console.WriteLine("\n--- Grade Evaluation ---");
        Console.Write("Enter a number (0-100) for grade calculation: ");
        int marks = int.Parse(Console.ReadLine());
        
        char grade = marks >= 90 ? 'A' : marks >= 80 ? 'B' : marks >= 70 ? 'C' : marks >= 60 ? 'D' : 'F';
        Console.WriteLine($"Your grade is: {grade}");
    }
}
