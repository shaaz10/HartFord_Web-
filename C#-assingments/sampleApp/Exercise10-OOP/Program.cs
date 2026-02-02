using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Exercise 10: Object-Oriented Programming ===\n");
        
        Console.WriteLine("--- Creating Objects ---");
        
        // Create student objects
        Student student1 = new Student("John", 20, 85);
        Student student2 = new Student("Sarah", 21, 92);
        Student student3 = new Student("Mike", 19, 78);
        
        Console.WriteLine("Student Information:");
        student1.DisplayInfo();
        Console.WriteLine();
        student2.DisplayInfo();
        Console.WriteLine();
        student3.DisplayInfo();
        
        Console.WriteLine("\n--- Static Counter ---");
        Console.WriteLine($"Total students created: {Student.GetTotalStudents()}");
        
        Console.WriteLine("\n--- Car Example ---");
        Car car1 = new Car("Toyota", "Camry", 2023);
        Car car2 = new Car("Honda", "Accord", 2022);
        
        car1.DisplayDetails();
        car1.Drive();
        car1.Stop();
        
        Console.WriteLine();
        
        car2.DisplayDetails();
        car2.Drive();
        car2.Stop();
    }
}

class Student
{
    private static int totalStudents = 0;
    private string name;
    private int age;
    private int marks;
    
    public Student(string name, int age, int marks)
    {
        this.name = name;
        this.age = age;
        this.marks = marks;
        totalStudents++;
    }
    
    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Marks: {marks}");
        Console.WriteLine($"Grade: {GetGrade()}");
    }
    
    private string GetGrade()
    {
        if (marks >= 90) return "A";
        if (marks >= 80) return "B";
        if (marks >= 70) return "C";
        if (marks >= 60) return "D";
        return "F";
    }
    
    public static int GetTotalStudents() => totalStudents;
}

class Car
{
    private string brand;
    private string model;
    private int year;
    private bool isRunning = false;
    
    public Car(string brand, string model, int year)
    {
        this.brand = brand;
        this.model = model;
        this.year = year;
    }
    
    public void DisplayDetails()
    {
        Console.WriteLine($"Car: {year} {brand} {model}");
    }
    
    public void Drive()
    {
        if (!isRunning)
        {
            Console.WriteLine("Starting the engine...");
            isRunning = true;
        }
        Console.WriteLine($"The {brand} {model} is driving...");
    }
    
    public void Stop()
    {
        Console.WriteLine($"The {brand} {model} has stopped.");
        isRunning = false;
    }
}
