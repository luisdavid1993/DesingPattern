using FactoryParttern;

internal class Program
{
    /// <summary>
    /// The Factory Method defines an interface for creating objects
    /// /but lets subclasses decide which classes to instantiate. 
    /// The Factory method lets a class defer instantiation to subclass.
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        ICustomer cust = Factory.Create("Customer");
        decimal billAmount = cust.TotalBill();
        Console.WriteLine(billAmount);
        Console.ReadLine();
    }
}