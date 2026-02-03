namespace OOPS_Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Emp emp = new Emp(1000);
            emp.Bal = 5000;
            Console.WriteLine(emp.Bal);
        }
    }
}

