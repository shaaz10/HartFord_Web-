using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Exercise 8: Methods/Functions ===\n");
        
        Console.WriteLine("--- Simple Arithmetic Methods ---");
        Console.Write("Enter first number: ");
        int a = int.Parse(Console.ReadLine());
        
        Console.Write("Enter second number: ");
        int b = int.Parse(Console.ReadLine());
        
        Console.WriteLine($"\nAddition: {Add(a, b)}");
        Console.WriteLine($"Subtraction: {Subtract(a, b)}");
        Console.WriteLine($"Multiplication: {Multiply(a, b)}");
        Console.WriteLine($"Division: {Divide(a, b)}");
        
        Console.WriteLine("\n--- More Methods ---");
        Console.WriteLine($"Power (2^8): {Power(2, 8)}");
        Console.WriteLine($"Factorial (5!): {Factorial(5)}");
        Console.WriteLine($"Is Prime (17): {IsPrime(17)}");
        Console.WriteLine($"Is Prime (10): {IsPrime(10)}");
        
        Console.WriteLine("\n--- String Manipulation ---");
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        Console.WriteLine($"Greeting: {Greet(name)}");
        Console.WriteLine($"Reversed: {ReverseString(name)}");
    }
    
    static int Add(int x, int y) => x + y;
    static int Subtract(int x, int y) => x - y;
    static int Multiply(int x, int y) => x * y;
    static double Divide(int x, int y) => y != 0 ? (double)x / y : 0;
    
    static double Power(double baseNum, int exponent)
    {
        return Math.Pow(baseNum, exponent);
    }
    
    static int Factorial(int n)
    {
        if (n <= 1) return 1;
        return n * Factorial(n - 1);
    }
    
    static bool IsPrime(int num)
    {
        if (num < 2) return false;
        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0) return false;
        }
        return true;
    }
    
    static string Greet(string name) => $"Hello, {name}! Welcome!";
    
    static string ReverseString(string str)
    {
        string reversed = "";
        for (int i = str.Length - 1; i >= 0; i--)
        {
            reversed += str[i];
        }
        return reversed;
    }
}
