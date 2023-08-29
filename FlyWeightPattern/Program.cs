using System.Net;

internal class Program
{
    /// <summary>
    /// STRUCTURAL
    /// Is useful where we need to create many objects and all this objects
    /// share some of common data
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Employee employee= new Employee();
        employee.Name = "Test";

        Employee employee2 = new Employee();
        employee2.Name = "Luis David";

        Console.WriteLine(employee);
        Console.WriteLine(employee2);

        Console.ReadLine();

    }
}

/// <summary>
///  all the address data is the same for all the amployees, but names changes
/// </summary>
public class Employee
{
    public string Name { get; set; }

    public AddressData AddressPro { get { return StaticAddress.address; } }

    public override string ToString()
    {
        return $"{Name} -- {AddressPro.Country} -- {AddressPro.City}";
    }
}

public class StaticAddress
{ 
 public static AddressData address = new AddressData(); 
}
public class AddressData
{
    public string Address { get; private set; } = "Cedritos";
    public string City { get; private set; } = "Bogotá";
    public string Country { get; private set; } = "Colombia";
    public string Pin { get; private set; } = "81";
}