using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        // Using LINQ to filter even numbers
        var evenNumbers = numbers.Where(n => n % 2 == 0);

        // Using LINQ to project squares of numbers
        var squares = numbers.Select(n => n * n);

        // Using LINQ to calculate the sum of numbers
        int sum = numbers.Sum();

        // Output results
        System.Console.WriteLine("Even Numbers: " + string.Join(", ", evenNumbers));
        System.Console.WriteLine("Squares: " + string.Join(", ", squares));
        System.Console.WriteLine("Sum: " + sum);


        var result =
        numbers
        .Where(n => n % 2 == 0)
        .Select(n => n * 10);

        foreach (var n in result)
        {
            Console.WriteLine(n);
        }

    }
}