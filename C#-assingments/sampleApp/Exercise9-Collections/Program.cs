using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Exercise 9: Collections (List & Dictionary) ===\n");
        
        Console.WriteLine("--- List Example: Manage Grocery Items ---");
        List<string> groceryList = new List<string>();
        
        Console.WriteLine("Add items to your list (type 'done' when finished):");
        while (true)
        {
            Console.Write("Enter item: ");
            string item = Console.ReadLine();
            if (item.ToLower() == "done") break;
            groceryList.Add(item);
        }
        
        Console.WriteLine("\n--- Your Grocery List ---");
        for (int i = 0; i < groceryList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {groceryList[i]}");
        }
        
        Console.WriteLine("\n--- Dictionary Example: Student Grades ---");
        Dictionary<string, int> grades = new Dictionary<string, int>
        {
            { "Alice", 85 },
            { "Bob", 92 },
            { "Charlie", 78 },
            { "David", 88 },
            { "Eve", 95 }
        };
        
        Console.WriteLine("Student Grades:");
        foreach (var entry in grades)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
        
        Console.WriteLine("\n--- Search in Dictionary ---");
        Console.Write("Enter student name to find grade: ");
        string searchName = Console.ReadLine();
        
        if (grades.TryGetValue(searchName, out int grade))
        {
            Console.WriteLine($"{searchName}'s grade is {grade}");
        }
        else
        {
            Console.WriteLine($"Student {searchName} not found.");
        }
        
        Console.WriteLine("\n--- LINQ Examples ---");
        Console.WriteLine("Grades above 85:");
        var aboveEightyFive = grades.Where(x => x.Value > 85);
        foreach (var student in aboveEightyFive)
        {
            Console.WriteLine($"{student.Key}: {student.Value}");
        }
        
        var topStudent = grades.OrderByDescending(x => x.Value).First();
        Console.WriteLine($"\nTop performer: {topStudent.Key} with {topStudent.Value} marks");
    }
}
