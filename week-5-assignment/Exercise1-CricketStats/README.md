# Exercise 1 - Cricket Statistics Pattern Prediction

## Description
This application predicts Dhoni's runs in Test cricket matches based on a series number using a mathematical pattern.

## Pattern
The pattern follows the formula: **n × (n+1) × (n+2) / 2**

Example:
- Series 0: 0 runs
- Series 1: 6 runs
- Series 2: 24 runs
- Series 3: 60 runs
- Series 4: 120 runs
- Series 5: 210 runs
- Series 6: 336 runs

## How to Run
1. Compile: `dotnet run`
2. Enter the series number when prompted
3. The application will display the predicted runs for that series

## Input
- Series number (non-negative integer)

## Output
- Predicted runs for the given series
- Pattern reference table (0-7 series)
