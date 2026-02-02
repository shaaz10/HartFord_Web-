using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Employee Salary Calculator ===\n");
        
        try
        {
            // Get employee details
            Console.WriteLine("Enter Employee Details:");
            Console.Write("Employee ID: ");
            string employeeId = Console.ReadLine();
            
            Console.Write("Employee Name: ");
            string employeeName = Console.ReadLine();
            
            Console.Write("Basic Salary: ");
            if (!double.TryParse(Console.ReadLine(), out double basicSalary))
            {
                Console.WriteLine("Invalid salary input.");
                return;
            }
            
            // Calculate net salary
            double netSalary = SalaryCalculator.CalculateNetSalary(basicSalary);
            
            // Display results
            Console.WriteLine("\n=== Salary Breakdown ===");
            Console.WriteLine($"Employee ID: {employeeId}");
            Console.WriteLine($"Employee Name: {employeeName}");
            Console.WriteLine($"Basic Salary: ?{basicSalary:F2}");
            
            double hra = basicSalary * 0.20;
            double da = basicSalary * 0.10;
            double pf = basicSalary >= 15000 ? basicSalary * 0.12 : 0;
            double grossSalary = basicSalary + hra + da;
            
            Console.WriteLine($"\nAllowances:");
            Console.WriteLine($"  HRA (20%): ?{hra:F2}");
            Console.WriteLine($"  DA (10%): ?{da:F2}");
            
            Console.WriteLine($"\nDeductions:");
            if (basicSalary >= 15000)
            {
                Console.WriteLine($"  PF (12%): ?{pf:F2}");
            }
            else
            {
                Console.WriteLine($"  PF: No deduction (Basic < ?15,000)");
            }
            
            Console.WriteLine($"\nGross Salary: ?{grossSalary:F2}");
            Console.WriteLine($"Net Salary: ?{netSalary:F2}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}
