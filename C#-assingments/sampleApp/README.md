# C# Basics Learning Solution - 10 Exercises

A comprehensive solution containing 10 foundational C# console applications demonstrating essential programming concepts.

## ?? Exercises Overview

### Exercise 1: Variables and Data Types
**Concepts**: int, double, string, char, bool, sizeof()
- Demonstrates declaration and usage of different data types
- Shows memory size of each type
- **Output**: Displays variable values and their types

### Exercise 2: Arithmetic Operations
**Concepts**: User input, parsing, arithmetic operators
- Gets two numbers from user input
- Performs: addition, subtraction, multiplication, division, modulus
- **Output**: Results of all arithmetic operations

### Exercise 3: Conditional Statements (if-else)
**Concepts**: if, else if, else, comparison operators
- Determines if number is positive, negative, or zero
- Checks if number is even or odd
- Classifies age group (child, teenager, adult)
- **Output**: Number classification and age category

### Exercise 4: Switch Statement
**Concepts**: switch cases, ternary operator, default case
- Fruit selection using switch statement
- Grade calculation using ternary operators
- **Output**: Fruit information and calculated grade

### Exercise 5: For Loop
**Concepts**: for loops, nested loops, accumulation
- Generates multiplication table
- Creates number triangle pattern
- Calculates sum of first N numbers
- **Output**: Tables, patterns, and sums

### Exercise 6: While and Do-While Loops
**Concepts**: while loops, do-while loops, loop control
- Countdown using while loop
- Menu system using do-while loop
- Sum calculation with input validation
- **Output**: Countdown, menu interactions, and total sum

### Exercise 7: Arrays
**Concepts**: 1D arrays, 2D arrays, array operations
- Student marks management in 1D array
- Calculates: total, average, highest, lowest marks
- 2D matrix input and display
- **Output**: Marks summary and matrix visualization

### Exercise 8: Methods/Functions
**Concepts**: Method definition, parameters, return values, recursion
- Basic arithmetic methods
- Power and factorial calculations
- Prime number checking
- String manipulation methods
- **Output**: Results of method calls and calculations

### Exercise 9: Collections
**Concepts**: List<T>, Dictionary<K,V>, LINQ
- Manages grocery list using List
- Student grades using Dictionary
- LINQ queries for filtering and sorting
- **Output**: List items, grades, filtered results, top performer

### Exercise 10: Object-Oriented Programming
**Concepts**: Classes, objects, properties, methods, static members
- Student class with grading logic
- Car class with behavior simulation
- Static counters and properties
- **Output**: Object information and method invocations

## ??? Project Structure

```
sampleApp/
??? Exercise1-VariablesAndDataTypes/
??? Exercise2-ArithmeticOperations/
??? Exercise3-ConditionalStatements/
??? Exercise4-SwitchStatement/
??? Exercise5-ForLoop/
??? Exercise6-WhileLoop/
??? Exercise7-Arrays/
??? Exercise8-Methods/
??? Exercise9-Collections/
??? Exercise10-OOP/
??? sampleApp.sln
```

Each exercise directory contains:
- `Program.cs` - Main application code
- `ExerciseX-Name.csproj` - Project file

## ? Key Features

? Interactive console applications  
? User input handling with validation  
? Comprehensive output formatting  
? Real-world examples (students, cars, fruits, etc.)  
? Comments explaining concepts  
? Progressive difficulty from basics to OOP  
? Small, focused demonstrations  

## ?? How to Run

### Run Individual Exercise
```bash
cd Exercise1-VariablesAndDataTypes
dotnet run
```

### Build Entire Solution
```bash
dotnet build sampleApp.sln
```

### Run Specific Exercise from Solution Root
```bash
dotnet run --project Exercise1-VariablesAndDataTypes
```

## ?? Running Examples

### Exercise 1: Variables and Data Types
```
=== Exercise 1: Variables and Data Types ===

Name: John Doe
Age: 25
Grade: A
Salary: $50000.50
Employed: True

--- Data Type Sizes ---
int size: 4 bytes
double size: 8 bytes
char size: 2 bytes
bool size: 1 byte
```

### Exercise 5: For Loop
```
=== Exercise 5: Loops - For Loop ===

--- Multiplication Table ---
Enter a number: 5

Multiplication table of 5:
5 × 1 = 5
5 × 2 = 10
...
5 × 10 = 50
```

### Exercise 10: OOP
```
=== Exercise 10: Object-Oriented Programming ===

--- Creating Objects ---
Student Information:
Name: John
Age: 20
Marks: 85
Grade: B

---
Total students created: 3
```

## ?? Learning Outcomes

After completing all exercises, you will understand:

- **Variables & Types**: Different data types and memory usage
- **Operators**: Arithmetic, comparison, and logical operations
- **Control Flow**: Conditional statements and switches
- **Loops**: For, while, and do-while loops with patterns
- **Arrays**: 1D and 2D array operations
- **Methods**: Function definition, parameters, and recursion
- **Collections**: Lists and Dictionaries with LINQ
- **OOP**: Classes, objects, and inheritance concepts

## ?? Requirements

- .NET 7.0 or higher
- Visual Studio 2022 or VS Code with C# extension
- PowerShell or Command Prompt

## ?? Tips for Learning

1. Run each exercise independently to understand concepts
2. Modify inputs to see how outputs change
3. Add additional logic to deepen understanding
4. Combine concepts from different exercises
5. Read comments to understand the purpose of each section

## ?? Notes

- All exercises are interactive and require user input (except Exercise 1)
- Exercises progressively introduce new concepts
- Code follows C# naming conventions and best practices
- Each exercise is self-contained and can be run independently

## ?? Next Steps

After mastering these basics:
- Explore inheritance and polymorphism
- Learn about interfaces and abstract classes
- Study exception handling
- Explore LINQ extensions
- Build larger projects with multiple classes
