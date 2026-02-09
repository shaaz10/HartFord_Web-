# Parking Lot Solution - Week 6 Assignment

This is a complete C# Console Application implementing the Parking Lot management system as per Week 6 requirements.

## Project Structure
- **Program.cs**: Main entry point containing the menu implementation and orchestration.
- **Vehicle.cs**: Core entity class with validation loop logic and comparison implementation.
- **Ticket.cs**: Dependent entity class for Vehicle.
- **ParkingLot.cs**: Manages the collection of vehicles (CRUD operations).
- **VehicleBO.cs**: Business Logic for searching vehicles.
- **ParkedTimeComparer.cs**: Custom comparer for sorting by parked time.

## Features
1. **Add Vehicle**: Create and validate vehicles (Requirement 2 & 3).
2. **Delete Vehicle**: Remove vehicles by Registration Number (Requirement 2).
3. **Display Vehicles**: Show all vehicles in a formatted table (Requirement 2).
4. **Search Vehicles**: Find by Type or Parked Time (Requirement 4).
5. **Sort Vehicles**: Sort by Weight or Parked Time (Requirement 5).
6. **Type Wise Count**: Show count of vehicles per type (Requirement 6).
7. **Compare Two Vehicles**: Dedicated Requirement 1 demo (Added as Option 8).

## How to Run
1. Navigate to the project directory:
   ```bash
   cd /Users/shaazhussain/Desktop/hartford-daily/C#-assingments/ParkingLot/ParkingLotFinal
   ```
2. Build the project:
   ```bash
   dotnet build
   ```
3. Run the application:
   ```bash
   dotnet run
   ```

## Input Format
When adding a vehicle, use the comma-separated format:
`registrationNo,name,type,weight,ticketNo,parkedTime,cost`

**Example:**
`TS 01 K 1562,Swift,Compact,1200.5,T001,09-02-2026 10:30:00,50.0`

## Validation Rules
- Registration Number format: `XX 00 X 0000` or `XX 00 0000`.
- Dates must inevitably match `dd-MM-yyyy HH:mm:ss`.
