/// <summary>
/// BEHAVIORAL
/// To reverse back to any old estate of one object
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        ICustomer customer = new Customer();
        customer.Id= 1;
        customer.CustomerType = "Normal";
        customer.CustomerName = "Luis David";
        customer.PhoneNumber= "1234567890";
        customer.BillAmount = 1235;
        customer.BillDate = DateTime.Now;
        customer.Address = "cra7588#5852-89";
        IMemento memento = (IMemento)customer;
        memento.Clone();
        Console.WriteLine(customer);

        customer.CustomerName = "Mariangelis";
        customer.BillAmount= 1000;
        memento.Revert();

        Console.WriteLine(customer);

        Console.ReadLine();



    }
}

public class Customer : ICustomer,IMemento
{
    public  ICustomer oldCopy { get; set; }
    public int Id { get; set; }
    public string CustomerType { get; set; }
    public string CustomerName { get; set; }
    public string PhoneNumber { get; set; }
    public decimal BillAmount { get; set; }
    public DateTime BillDate { get; set; }
    public string Address { get; set; }

    public Customer() { 
    
    }


    public override string ToString()
    {
        return $" {CustomerType} {CustomerName} -- {CustomerType} -- {PhoneNumber} -- {Address} -- BillAmount {BillAmount}";
    }

    public void Clone()
    {
        oldCopy = (ICustomer)this.MemberwiseClone();
    }

    public void Revert()
    {
        this.CustomerType = oldCopy.CustomerType;
        this.CustomerName = oldCopy.CustomerName;
        this.PhoneNumber = oldCopy.PhoneNumber;
        this.BillAmount = oldCopy.BillAmount;
        this.BillDate = oldCopy.BillDate;
        this.Address = oldCopy.Address;
    }
}

public interface ICustomer
{
    int Id { get; set; }
    string CustomerType { get; set; }
    string CustomerName { get; set; }
    string PhoneNumber { get; set; }
    decimal BillAmount { get; set; }
    DateTime BillDate { get; set; }
    string Address { get; set; }
  

}

public interface IMemento
{
    void Clone();
    void Revert(); // revert to old copy
}

