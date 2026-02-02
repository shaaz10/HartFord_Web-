# Exercise 3 - Employee Salary Calculator

## Description
A C# library and console application to calculate an employee's net salary based on basic salary with proper deductions and allowances.

## Salary Components

### Allowances
- **HRA (House Rent Allowance)**: 20% of Basic Salary
- **DA (Dearness Allowance)**: 10% of Basic Salary

### Deductions
- **PF (Provident Fund)**: 12% of Basic Salary (only if Basic ? ?15,000)

**Gross Salary** = Basic + HRA + DA  
**Net Salary** = Gross Salary - PF

## How to Run
1. Compile: `dotnet run`
2. Enter employee details:
   - Employee ID
   - Employee Name
   - Basic Salary
3. The application will display the salary breakdown

## Exception Handling
- Implements basic exception handling for invalid inputs
- Validates negative salaries

## Example
```
Basic Salary: ?20,000
HRA (20%): ?4,000
DA (10%): ?2,000
Gross Salary: ?26,000
PF (12%): ?2,400
Net Salary: ?23,600
```

## Library Usage
The `SalaryCalculator` class provides:
```csharp
public static double CalculateNetSalary(double basicSalary)
```

Can be used in other applications by referencing this library.
