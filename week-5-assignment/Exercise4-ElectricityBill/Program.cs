using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("??????????????????????????????????????????????????");
        Console.WriteLine("?        ELECTRICITY BILL CALCULATOR             ?");
        Console.WriteLine("??????????????????????????????????????????????????\n");
        
        try
        {
            // Get customer details
            Console.WriteLine("Enter Customer Details:");
            Console.Write("Customer ID: ");
            string customerId = Console.ReadLine();
            
            Console.Write("Customer Name: ");
            string customerName = Console.ReadLine();
            
            Console.Write("Address: ");
            string address = Console.ReadLine();
            
            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine();
            
            Console.Write("Email ID: ");
            string emailId = Console.ReadLine();
            
            // Get connection type
            Console.WriteLine("\nConnection Type:");
            Console.WriteLine("1. Industrial");
            Console.WriteLine("2. Business");
            Console.WriteLine("3. Domestic");
            Console.WriteLine("4. Agricultural");
            Console.Write("Select (1-4): ");
            string connectionTypeInput = Console.ReadLine();
            
            string connectionType = GetConnectionType(connectionTypeInput);
            if (connectionType == "Invalid")
            {
                Console.WriteLine("Invalid connection type.");
                return;
            }
            
            // Get meter readings
            Console.Write("\nPrevious Reading: ");
            if (!double.TryParse(Console.ReadLine(), out double previousReading) || previousReading < 0)
            {
                Console.WriteLine("Invalid previous reading.");
                return;
            }
            
            Console.Write("Current Reading: ");
            if (!double.TryParse(Console.ReadLine(), out double currentReading) || currentReading < previousReading)
            {
                Console.WriteLine("Invalid current reading.");
                return;
            }
            
            // Calculate bill
            double unitsConsumed = currentReading - previousReading;
            double electricityCharges = CalculateElectricityCharges(unitsConsumed);
            double meterRent = GetMeterRent(connectionType);
            double totalBill = electricityCharges + meterRent;
            
            // Display bill
            DisplayBill(customerId, customerName, address, phoneNumber, emailId, 
                       connectionType, previousReading, currentReading, unitsConsumed, 
                       electricityCharges, meterRent, totalBill);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    static string GetConnectionType(string input)
    {
        return input switch
        {
            "1" => "Industrial",
            "2" => "Business",
            "3" => "Domestic",
            "4" => "Agricultural",
            _ => "Invalid"
        };
    }
    
    static double CalculateElectricityCharges(double units)
    {
        double charges = 0;
        
        if (units <= 100)
        {
            charges = units * 1.5;
        }
        else if (units <= 250)
        {
            charges = (100 * 1.5) + ((units - 100) * 2.5);
        }
        else if (units <= 550)
        {
            charges = (100 * 1.5) + (150 * 2.5) + ((units - 250) * 4.5);
        }
        else
        {
            charges = (100 * 1.5) + (150 * 2.5) + (300 * 4.5) + ((units - 550) * 7.5);
        }
        
        return charges;
    }
    
    static double GetMeterRent(string connectionType)
    {
        return connectionType switch
        {
            "Industrial" => 2500,
            "Business" => 1500,
            "Domestic" => 1000,
            "Agricultural" => 0, // Free
            _ => 0
        };
    }
    
    static void DisplayBill(string customerId, string customerName, string address, 
                           string phoneNumber, string emailId, string connectionType, 
                           double previousReading, double currentReading, double unitsConsumed, 
                           double electricityCharges, double meterRent, double totalBill)
    {
        Console.WriteLine("\n??????????????????????????????????????????????????");
        Console.WriteLine("?              ELECTRICITY BILL                  ?");
        Console.WriteLine("??????????????????????????????????????????????????\n");
        
        Console.WriteLine("CUSTOMER INFORMATION");
        Console.WriteLine("?".PadRight(46, '?'));
        Console.WriteLine($"Customer ID:        {customerId}");
        Console.WriteLine($"Customer Name:      {customerName}");
        Console.WriteLine($"Address:            {address}");
        Console.WriteLine($"Phone Number:       {phoneNumber}");
        Console.WriteLine($"Email ID:           {emailId}");
        Console.WriteLine($"Connection Type:    {connectionType}");
        
        Console.WriteLine("\nMETER DETAILS");
        Console.WriteLine("?".PadRight(46, '?'));
        Console.WriteLine($"Previous Reading:   {previousReading:F0} units");
        Console.WriteLine($"Current Reading:    {currentReading:F0} units");
        Console.WriteLine($"Units Consumed:     {unitsConsumed:F0} units");
        
        Console.WriteLine("\nCHARGES BREAKDOWN");
        Console.WriteLine("?".PadRight(46, '?'));
        Console.WriteLine($"Electricity Charges: ?{electricityCharges:F2}");
        Console.WriteLine($"Meter Rent ({connectionType}): ?{meterRent:F2}");
        
        Console.WriteLine("\n" + "?".PadRight(46, '?'));
        Console.WriteLine($"TOTAL AMOUNT DUE:   ?{totalBill:F2}");
        Console.WriteLine("?".PadRight(46, '?'));
    }
}
