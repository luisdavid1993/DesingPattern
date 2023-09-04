/// <summary>
/// Fluent Interfaces 
///It simplifies your object consumption code by making your code more simple, readable and discoverable.
///Method chaining 
///Is a common technique where each method returns an object and all these methods can be chained together to form a single statement.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Customer customer = new Customer();
        customer.FullName = "Luis David";
        customer.DoB = Convert.ToDateTime("31/01/1993");
        customer.Address = "Valencia España";


        CustomerFluent fluent = new CustomerFluent();

        fluent.NameOfThePerson("Luis David")
            .Born("31/01/1993")
            .StayAt("Valencia España");



        CustomerHandler handler = new CustomerHandler();
        Customer customer1 = handler.SetAddress("Valencia España")
            .SetDob("31/01/1993")
            .SetFullName("Luis David")
            .GetCustomer();

        Console.WriteLine(customer1);

    }
}



public class CustomerFluent
{
    private Customer objCustomer = new Customer();

    public CustomerFluent NameOfThePerson(string fullName)
    {
        objCustomer.FullName= fullName;
        return this;
    }
    public CustomerFluent Born(string dateOfBithDay)
    {
        objCustomer.DoB = Convert.ToDateTime(dateOfBithDay);
        return this;
    }

    public void StayAt(string address)
    {
        objCustomer.Address= address;
    }
}
public class Customer
{
    public string FullName { get; set; }
    public DateTime DoB { get; set; }
    public string Address { get; set; }

    public override string ToString()
    {
        return $"{FullName} --- {DoB} --- {Address}";
    }
}

public class CustomerHandler
{
    private Customer objCustomer = new Customer();

    public CustomerHandler SetFullName(string name)
    {
        objCustomer.FullName = name;
        return this;
    }
    public CustomerHandler SetDob(string dateOfBirthDay)
    {
        objCustomer.DoB = Convert.ToDateTime(dateOfBirthDay);
        return this;
    }

    public CustomerHandler SetAddress(string addres)
    {
        objCustomer.Address = addres;
        return this;
    }

    public Customer GetCustomer()
    {
        return objCustomer;
    }
}