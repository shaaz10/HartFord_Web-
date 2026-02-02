using System;

public class SalaryCalculator
{
    public static double CalculateNetSalary(double basicSalary)
    {
        if (basicSalary < 0)
        {
            throw new ArgumentException("Basic salary cannot be negative.");
        }
        
        double hra = basicSalary * 0.20; // 20% of Basic
        double da = basicSalary * 0.10;  // 10% of Basic
        double pf = 0;                   // No PF deduction if basic < 15000
        
        // PF = 12% of Basic only if Basic >= 15000
        if (basicSalary >= 15000)
        {
            pf = basicSalary * 0.12;
        }
        
        double grossSalary = basicSalary + hra + da;
        double netSalary = grossSalary - pf;
        
        return netSalary;
    }
}
