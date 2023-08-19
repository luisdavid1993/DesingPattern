using FactoryDesingPattern;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        ICustomer cust = Factory.Create("Customer");
        decimal billAmount = cust.TotalBill();
        Console.WriteLine(billAmount);
        Console.ReadLine();
    }
}

