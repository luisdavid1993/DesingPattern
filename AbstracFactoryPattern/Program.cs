using AbstracFactoryPattern;

internal class Program
{
    /// <summary>
    ///  CREATIONAL
    /// Provide an interface for creating families of related or dependent objects without specifying their concrete class.
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        ICustomer normalCustomer = Factory.CreateNormalCustomer("Customer");
        ICustomer corporateCustomer = Factory.CreateCorporateCustomer("CorporatePublic");
        normalCustomer.TotalBill();
        corporateCustomer.TotalBill();
    }
}