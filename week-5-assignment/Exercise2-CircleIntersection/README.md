# Exercise 2 - Circle Intersection Game

## Description
This game helps Mahi determine the relationship between two circles based on their centers and radii.

## Features
Determines if:
- **B is in A** (B is completely inside A)
- **A is in B** (A is completely inside B)
- **A and B intersect** (circles overlap at two points)
- **Circles do not intersect** (circles are completely separate or one is inside the other)

## How to Run
1. Compile: `dotnet run`
2. Enter Circle A details:
   - Radius (ra)
   - Center X coordinate (xa)
   - Center Y coordinate (ya)
3. Enter Circle B details:
   - Radius (rb)
   - Center X coordinate (xb)
   - Center Y coordinate (yb)
4. The application will display the relationship between the circles

## Formula Used
Distance between centers = ?[(xb - xa)² + (yb - ya)²]

## Relationship Conditions
- If distance > sum of radii: Circles are separate
- If distance = sum of radii: Circles touch externally
- If distance < difference of radii: One circle is inside the other
- If distance = difference of radii: Circles touch internally
- Otherwise: Circles intersect at two points
