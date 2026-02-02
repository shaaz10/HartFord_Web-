using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Exercise 2: Arithmetic Operations ===\n");
        
        Console.Write("Enter first number: ");
        double num1 = double.Parse(Console.ReadLine());
        
        Console.Write("Enter second number: ");
        double num2 = double.Parse(Console.ReadLine());
        
        double addition = num1 + num2;
        double subtraction = num1 - num2;
        double multiplication = num1 * num2;
        double division = num1 / num2;
        double modulus = num1 % num2;
        
        Console.WriteLine("\n--- Results ---");
        Console.WriteLine($"Addition: {num1} + {num2} = {addition}");
        Console.WriteLine($"Subtraction: {num1} - {num2} = {subtraction}");
        Console.WriteLine($"Multiplication: {num1} * {num2} = {multiplication}");
        Console.WriteLine($"Division: {num1} / {num2} = {division}");
        Console.WriteLine($"Modulus: {num1} % {num2} = {modulus}");
    }
}
