using System;
using System.Collections.Generic;

namespace ExtensionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);

            // Using extension methods
            numbers.PrintAll();

            Console.WriteLine("Sum: " + numbers.SumAll());

            numbers.AddIfNotExists(20); // ignored
            numbers.AddIfNotExists(50); // added

            Console.WriteLine("After AddIfNotExists:");
            numbers.PrintAll();
        }
    }
}
