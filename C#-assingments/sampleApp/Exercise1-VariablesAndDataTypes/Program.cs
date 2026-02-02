using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Exercise 1: Variables and Data Types ===\n");
        
        // Demonstrate different data types
        int age = 25;
        double salary = 50000.50;
        string name = "John Doe";
        bool isEmployed = true;
        char grade = 'A';
        
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Grade: {grade}");
        Console.WriteLine($"Salary: ${salary}");
        Console.WriteLine($"Employed: {isEmployed}");
        
        Console.WriteLine("\n--- Data Type Sizes ---");
        Console.WriteLine($"int size: {sizeof(int)} bytes");
        Console.WriteLine($"double size: {sizeof(double)} bytes");
        Console.WriteLine($"char size: {sizeof(char)} bytes");
        Console.WriteLine($"bool size: {sizeof(bool)} byte");
    }
}
