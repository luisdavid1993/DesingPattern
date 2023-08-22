/// <summary>
/// CREATIONAL
/// Create a new copy of the object (Clone an object).
/// By cloning, any changes to the cloned object does not affect the original object. 
///Shallow Cloning
//Only the parent is cloning. By using MemberwiseClone
///Deep Cloning
//The parent and child object are cloning.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Customer customer = new Customer(100,"Luis David","Martinez");
        customer.Directions = new List<Address>()
                                               {
                                               new Address() { Direction = "cra 7hfhf#16"},
                                               new Address(){ Direction = "cra 8hfhf#16"}
                                              };

        Customer customer1 = customer.DeepClone();
        customer1.Directions[0].Direction = "new direction";

        Console.WriteLine(customer);
        Console.WriteLine(customer1);

        Console.ReadLine();
    }
}

public class Customer
{
    public int CustomerCode { get; set; }
    public string? Name { get; set; }
    public string? LasteName { get; set; }
    public List<Address> Directions { get; set; }
    public Customer(int customerCode, string? name, string? lasteName)
    {
        CustomerCode = customerCode;
        Name = name;
        LasteName = lasteName;
    }

    public Customer ShallowClone()
    {
        return (Customer)this.MemberwiseClone();
    }
    public Customer DeepClone()
    {
        Customer customer = (Customer)this.MemberwiseClone();
        Address address = new Address();
        customer.Directions = this.Directions.Select(x=> x.ShallowClone()).ToList();
        return customer;
    }

    public override string ToString()
    {
        string cust = $"{Name} -- {LasteName}";
        foreach (var item in Directions)
        {
            cust += $"{Environment.NewLine} {item.Direction}";
        }
        return cust;
    }

}

public class Address 
{ 
    public string Direction { get; set; }

    public Address ShallowClone()
    {
        return (Address)this.MemberwiseClone();
    }
}