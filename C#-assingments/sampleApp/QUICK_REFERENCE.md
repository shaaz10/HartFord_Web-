# EXERCISE QUICK REFERENCE GUIDE

## ?? Complete Summary of All 10 C# Basic Exercises

### Project Location
```
C#-assingments/sampleApp/
```

### Solution File
```
sampleApp.sln - Contains all 10 exercises
```

---

## ? Exercise 1: Variables and Data Types

**File**: `Exercise1-VariablesAndDataTypes/Program.cs`

**Key Concepts**:
- Variable declaration and initialization
- Different data types (int, double, string, char, bool)
- Memory size of each type

**What It Does**:
- Displays employee information with different types
- Shows memory size in bytes for each type

**Sample Output**:
```
Name: John Doe
Age: 25
Grade: A
Salary: $50000.50
Employed: True

int size: 4 bytes
double size: 8 bytes
```

**Run Command**: `dotnet run --project Exercise1-VariablesAndDataTypes`

---

## ? Exercise 2: Arithmetic Operations

**File**: `Exercise2-ArithmeticOperations/Program.cs`

**Key Concepts**:
- User input with Console.ReadLine()
- Type conversion with Parse()
- Arithmetic operators (+, -, *, /, %)

**What It Does**:
- Gets two numbers from user
- Performs all 5 basic arithmetic operations
- Displays results

**Sample Input/Output**:
```
Input: 10, 3
Addition: 10 + 3 = 13
Subtraction: 10 - 3 = 7
Multiplication: 10 * 3 = 30
Division: 10 / 3 = 3.33...
Modulus: 10 % 3 = 1
```

**Run Command**: `dotnet run --project Exercise2-ArithmeticOperations`

---

## ? Exercise 3: Conditional Statements (if-else)

**File**: `Exercise3-ConditionalStatements/Program.cs`

**Key Concepts**:
- if, else if, else statements
- Nested conditions
- Comparison operators

**What It Does**:
- Determines if number is positive/negative/zero
- Checks if even or odd
- Classifies age group

**Sample Logic**:
```
if (number > 0) ? Positive
else if (number < 0) ? Negative
else ? Zero

if (number >= 18) ? Adult
else if (number >= 13) ? Teenager
else ? Child
```

**Run Command**: `dotnet run --project Exercise3-ConditionalStatements`

---

## ? Exercise 4: Switch Statement

**File**: `Exercise4-SwitchStatement/Program.cs`

**Key Concepts**:
- switch case syntax
- break statements
- default case
- Ternary operator

**What It Does**:
- Fruit selection menu
- Grade calculation using ternary operators

**Sample Cases**:
```
1 ? Apple
2 ? Banana
3 ? Orange
4 ? Mango
5 ? Grapes
```

**Ternary Operator**:
```csharp
grade = marks >= 90 ? 'A' : marks >= 80 ? 'B' : 'C';
```

**Run Command**: `dotnet run --project Exercise4-SwitchStatement`

---

## ? Exercise 5: For Loop

**File**: `Exercise5-ForLoop/Program.cs`

**Key Concepts**:
- for loop syntax
- Nested loops
- Loop counters

**What It Does**:
1. Generates multiplication table
2. Creates number triangle pattern
3. Calculates sum of first N numbers

**Examples**:
```
Multiplication table of 5:
5 × 1 = 5
5 × 2 = 10
...

Number Triangle:
1
1 2
1 2 3
1 2 3 4
```

**Run Command**: `dotnet run --project Exercise5-ForLoop`

---

## ? Exercise 6: While and Do-While Loops

**File**: `Exercise6-WhileLoop/Program.cs`

**Key Concepts**:
- while loop condition checking
- do-while loop (execute before checking)
- Loop control

**What It Does**:
1. Countdown using while
2. Menu system using do-while
3. Sum calculation with validation

**Key Pattern**:
```csharp
// While - checks condition first
while (condition) { }

// Do-While - executes at least once
do { } while (condition);
```

**Run Command**: `dotnet run --project Exercise6-WhileLoop`

---

## ? Exercise 7: Arrays

**File**: `Exercise7-Arrays/Program.cs`

**Key Concepts**:
- 1D array declaration and usage
- 2D array (matrix)
- Array operations (sum, average, max, min)

**What It Does**:
1. Manages student marks in array
2. Calculates statistics (sum, average, high, low)
3. Takes 2D matrix input and displays it

**Array Operations**:
```csharp
int[] marks = new int[5];          // 1D array
int[,] matrix = new int[3, 3];     // 2D array
marks[0] = 85;                     // Assignment
marks.Length;                       // Get size
```

**Run Command**: `dotnet run --project Exercise7-Arrays`

---

## ? Exercise 8: Methods/Functions

**File**: `Exercise8-Methods/Program.cs`

**Key Concepts**:
- Method definition with parameters
- Return values
- Recursion (factorial)
- Arrow functions (=>)

**Methods Included**:
```csharp
Add(a, b)           // Simple addition
Power(base, exp)    // Exponentiation
Factorial(n)        // Recursion: n! = n * (n-1)!
IsPrime(num)        // Prime number check
ReverseString(str)  // String manipulation
```

**Key Example - Factorial Recursion**:
```csharp
static int Factorial(int n)
{
    if (n <= 1) return 1;
    return n * Factorial(n - 1);
}
```

**Run Command**: `dotnet run --project Exercise8-Methods`

---

## ? Exercise 9: Collections

**File**: `Exercise9-Collections/Program.cs`

**Key Concepts**:
- List<T> for dynamic arrays
- Dictionary<K, V> for key-value pairs
- LINQ for querying collections
- foreach loops

**What It Does**:
1. Grocery list management with List
2. Student grades with Dictionary
3. LINQ filtering and sorting

**Examples**:
```csharp
List<string> groceries = new List<string>();
groceries.Add("Apple");
groceries.Count;

Dictionary<string, int> grades = new Dictionary<string, int>();
grades["Alice"] = 85;
grades.TryGetValue("Alice", out int grade);

// LINQ
var topGrades = grades.Where(x => x.Value > 85);
var topStudent = grades.OrderByDescending(x => x.Value).First();
```

**Run Command**: `dotnet run --project Exercise9-Collections`

---

## ? Exercise 10: Object-Oriented Programming

**File**: `Exercise10-OOP/Program.cs`

**Key Concepts**:
- Class definition
- Object instantiation
- Properties and methods
- Static members
- Encapsulation

**Classes in This Exercise**:

### Student Class
```csharp
class Student
{
    private static int totalStudents = 0;
    private string name, age, marks;
    
    public Student(string name, int age, int marks) { }
    public void DisplayInfo() { }
    private string GetGrade() { }
}
```

### Car Class
```csharp
class Car
{
    private string brand, model;
    private bool isRunning;
    
    public void Drive() { }
    public void Stop() { }
}
```

**What It Does**:
1. Creates Student and Car objects
2. Demonstrates instance methods
3. Shows static counters
4. Displays object behavior

**Run Command**: `dotnet run --project Exercise10-OOP`

---

## ?? Difficulty Progression

```
Easy     ? Exercises 1-3  (Variables, Operators, Conditions)
Medium   ? Exercises 4-7  (Loops, Collections, Arrays)
Advanced ? Exercises 8-10 (Methods, LINQ, OOP)
```

---

## ?? How to Run All Exercises

### Option 1: Run Individual Exercise
```bash
cd C#-assingments/sampleApp
dotnet run --project Exercise1-VariablesAndDataTypes
```

### Option 2: Build Entire Solution
```bash
cd C#-assingments/sampleApp
dotnet build sampleApp.sln
```

### Option 3: Run from Specific Directory
```bash
cd C#-assingments/sampleApp/Exercise5-ForLoop
dotnet run
```

---

## ?? Learning Path

1. **Start**: Exercises 1-3 (Understanding basics)
2. **Practice**: Exercises 4-7 (Loops and collections)
3. **Master**: Exercises 8-10 (Advanced concepts)
4. **Modify**: Change inputs, add features to each exercise
5. **Combine**: Use concepts from multiple exercises in one program

---

## ?? Key Syntax Quick Reference

### Variables
```csharp
int age = 25;
string name = "John";
double salary = 50000.50;
bool isActive = true;
```

### Conditionals
```csharp
if (age > 18) { }
else if (age == 18) { }
else { }

switch (choice) { case 1: break; }
```

### Loops
```csharp
for (int i = 0; i < 10; i++) { }
while (condition) { }
do { } while (condition);
```

### Arrays
```csharp
int[] numbers = new int[5];
int[,] matrix = new int[3, 3];
```

### Methods
```csharp
public int Add(int a, int b) => a + b;
public void Display() { }
```

### Collections
```csharp
List<int> list = new List<int>();
Dictionary<string, int> dict = new Dictionary<string, int>();
```

### Classes
```csharp
class Student
{
    public void DisplayInfo() { }
}
```

---

## ?? Next Steps After Completing All 10 Exercises

? Study inheritance and polymorphism
? Learn interfaces and abstract classes
? Explore exception handling (try-catch)
? Practice more LINQ operations
? Build a real project using multiple concepts
? Study design patterns
? Learn async/await programming

---

## ?? Tips for Success

1. **Run each exercise multiple times** with different inputs
2. **Modify the code** to understand it better
3. **Combine exercises** - use methods from Ex8 with arrays from Ex7
4. **Add error handling** - prevent crashes with invalid input
5. **Create variations** - make similar programs with different themes
6. **Read the code** - understand not just what, but how and why
7. **Experiment** - don't be afraid to break things and fix them

---

## ? Exercise Summary Table

| # | Name | Key Topic | Difficulty |
|---|------|-----------|-----------|
| 1 | Variables & Types | Data types | ? Easy |
| 2 | Arithmetic | Operators | ? Easy |
| 3 | Conditionals | if-else | ? Easy |
| 4 | Switch | switch-case | ?? Medium |
| 5 | For Loop | Loops | ?? Medium |
| 6 | While Loop | Loop control | ?? Medium |
| 7 | Arrays | Collections | ?? Medium |
| 8 | Methods | Functions | ?? Medium |
| 9 | Collections | List & Dict | ??? Hard |
| 10 | OOP | Classes | ??? Hard |

---

**Created**: February 2026
**Repository**: https://github.com/shaaz10/HartFord_Web-
**Branch**: main
