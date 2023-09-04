using System.Collections;
using System.Net;
/// <summary>
/// BEHAVIORAL
///Its way of separating the logic and algorithm from the current data structure.
///You can add new logic to the current data structure without altering the structure.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

       

        Customer customer = new Customer();
        customer.CustomerName = "luis David";

        Address address = new Address();
        address.Address1 = "Valencia España";
        address.Address2 = "Venezuela";

        Phone phone = new Phone();
        phone.PhoneNumber = "+346548962";

        customer.objAddress.Add(address);
        address.objPhones.Add(phone);

        VisitorString visitorString = new VisitorString();
        customer.Accept(visitorString);
        Console.WriteLine(visitorString.strData);


        VisitorXML visitorxml= new VisitorXML();
        customer.Accept(visitorxml);
        Console.WriteLine(visitorxml.strData);

        Console.ReadLine();

    }
}

public interface IVisitor
{
    void Visit(Customer customer);
    void Visit(Address address);
    void Visit(Phone phone);
}

public class VisitorString : IVisitor
{
    public string strData = string.Empty;
    public void Visit(Customer customer)
    {
        strData = $"Customer name {customer.CustomerName}";
    }

    public void Visit(Address address)
    {
        strData += $"Addres 1 {address.Address1}";
        strData += $"Addres 2 {address.Address2}";
    }

    public void Visit(Phone phone)
    {
        strData += $"Phone Number {phone.PhoneNumber}";
    }
}

public class VisitorXML: IVisitor
{
    public string strData = string.Empty;
    public void Visit(Customer customer)
    {
        strData = $"<Customer> {customer.CustomerName} </Customer>";
    }

    public void Visit(Address address)
    {
        strData += $"<Addres1> {address.Address1} </Addres1>";
        strData += $"<Addres2> {address.Address2} </Addres2>";
    }

    public void Visit(Phone phone)
    {
        strData += $"<PhoneNumber> {phone.PhoneNumber} </PhoneNumber>";
    }
}

public interface IcustomerElements
{
    void Accept(IVisitor visitor);
}

public class Customer: IcustomerElements
{
    public string CustomerName { get; set; }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
        foreach (Address item in objAddress)
        {
            item.Accept(visitor);
        }
    }

    public ArrayList objAddress = new ArrayList();
}
public class Address: IcustomerElements
{
    public string  Address1 { get; set; }
    public string Address2 { get; set; }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
        foreach (Phone item in objPhones)
        {
            item.Accept(visitor);
        }
    }

   public ArrayList objPhones = new ArrayList();
}

public class Phone: IcustomerElements
{
    public string PhoneNumber { get; set; }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}