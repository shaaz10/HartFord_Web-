using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Exercise 3: Conditional Statements (if-else) ===\n");
        
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        
        if (number > 0)
        {
            Console.WriteLine($"{number} is a positive number.");
            
            if (number % 2 == 0)
                Console.WriteLine($"{number} is even.");
            else
                Console.WriteLine($"{number} is odd.");
        }
        else if (number < 0)
        {
            Console.WriteLine($"{number} is a negative number.");
        }
        else
        {
            Console.WriteLine("The number is zero.");
        }
        
        Console.WriteLine("\n--- Number Classification ---");
        if (number >= 18)
            Console.WriteLine("You are an adult.");
        else if (number >= 13)
            Console.WriteLine("You are a teenager.");
        else
            Console.WriteLine("You are a child.");
    }
}
