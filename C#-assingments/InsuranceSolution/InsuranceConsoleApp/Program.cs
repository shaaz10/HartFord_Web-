using System;
using InsuranceLibrary.Models;
using InsuranceLibrary.Services;

class Program
{
    static PolicyService service = new PolicyService();

    static void Main()
    {
        int choice;
        do
        {
            Console.WriteLine("\n1. Add Policy");
            Console.WriteLine("2. View All Policies");
            Console.WriteLine("3. Search Policy by ID");
            Console.WriteLine("4. Update Policy");
            Console.WriteLine("5. Delete Policy");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1: AddPolicy(); break;
                case 2: ViewPolicies(); break;
                case 3: SearchPolicy(); break;
                case 4: UpdatePolicy(); break;
                case 5: DeletePolicy(); break;
            }

        } while (choice != 0);
    }

    static void AddPolicy()
    {
        Console.Write("Policy ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Holder Name: ");
        string name = Console.ReadLine();

        Console.Write("Policy Type: ");
        string type = Console.ReadLine();

        Console.Write("Premium: ");
        decimal premium = decimal.Parse(Console.ReadLine());

        Console.Write("Term (years): ");
        int term = int.Parse(Console.ReadLine());

        service.AddPolicy(new InsurancePolicy(id, name, type, premium, term));
        Console.WriteLine("Policy Added!");
    }

    static void ViewPolicies()
    {
        foreach (var policy in service.GetAllPolicies())
        {
            Console.WriteLine(policy);
        }
    }

    static void SearchPolicy()
    {
        Console.Write("Enter Policy ID: ");
        int id = int.Parse(Console.ReadLine());

        var policy = service.GetPolicyById(id);
        Console.WriteLine( "Policy Not Found");
    }

    static void UpdatePolicy()
    {
        Console.Write("Policy ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("New Premium: ");
        decimal premium = decimal.Parse(Console.ReadLine());

        Console.Write("New Term: ");
        int term = int.Parse(Console.ReadLine());

        Console.WriteLine(service.UpdatePolicy(id, premium, term)
            ? "Policy Updated"
            : "Policy Not Found");
    }

    static void DeletePolicy()
    {
        Console.Write("Policy ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine(service.DeletePolicy(id)
            ? "Policy Deleted"
            : "Policy Not Found");
    }
}
