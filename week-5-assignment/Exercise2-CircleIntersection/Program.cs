using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Circle Intersection Game ===\n");
        
        // Get Circle A details
        Console.WriteLine("Enter Circle A details:");
        Console.Write("Radius (ra): ");
        if (!double.TryParse(Console.ReadLine(), out double ra) || ra <= 0)
        {
            Console.WriteLine("Invalid radius input.");
            return;
        }
        
        Console.Write("Center X coordinate (xa): ");
        if (!double.TryParse(Console.ReadLine(), out double xa))
        {
            Console.WriteLine("Invalid coordinate input.");
            return;
        }
        
        Console.Write("Center Y coordinate (ya): ");
        if (!double.TryParse(Console.ReadLine(), out double ya))
        {
            Console.WriteLine("Invalid coordinate input.");
            return;
        }
        
        // Get Circle B details
        Console.WriteLine("\nEnter Circle B details:");
        Console.Write("Radius (rb): ");
        if (!double.TryParse(Console.ReadLine(), out double rb) || rb <= 0)
        {
            Console.WriteLine("Invalid radius input.");
            return;
        }
        
        Console.Write("Center X coordinate (xb): ");
        if (!double.TryParse(Console.ReadLine(), out double xb))
        {
            Console.WriteLine("Invalid coordinate input.");
            return;
        }
        
        Console.Write("Center Y coordinate (yb): ");
        if (!double.TryParse(Console.ReadLine(), out double yb))
        {
            Console.WriteLine("Invalid coordinate input.");
            return;
        }
        
        // Calculate distance between centers
        double distance = Math.Sqrt(Math.Pow(xb - xa, 2) + Math.Pow(yb - ya, 2));
        
        // Determine relationship
        Console.WriteLine($"\n=== Result ===");
        Console.WriteLine($"Distance between centers: {distance:F2}");
        Console.WriteLine($"Sum of radii: {ra + rb:F2}");
        Console.WriteLine($"Difference of radii: {Math.Abs(ra - rb):F2}");
        
        string relationship = DetermineCircleRelationship(distance, ra, rb);
        Console.WriteLine($"\n{relationship}");
    }
    
    static string DetermineCircleRelationship(double distance, double ra, double rb)
    {
        double epsilon = 0.0001; // For floating point comparison
        double sumRadii = ra + rb;
        double diffRadii = Math.Abs(ra - rb);
        
        if (distance < epsilon)
        {
            // Circles are concentric or identical
            if (Math.Abs(ra - rb) < epsilon)
                return "Circles are identical (same center and radius)";
            else
                return "Circles are concentric (same center, different radii)";
        }
        else if (distance > sumRadii + epsilon)
        {
            return "Circles are completely separate - A and B do not intersect";
        }
        else if (Math.Abs(distance - sumRadii) < epsilon)
        {
            return "Circles touch externally at one point";
        }
        else if (distance < diffRadii - epsilon)
        {
            return "One circle is inside the other - A and B do not intersect";
        }
        else if (Math.Abs(distance - diffRadii) < epsilon)
        {
            return "Circles touch internally at one point";
        }
        else
        {
            return "A and B intersect at two points";
        }
    }
}
