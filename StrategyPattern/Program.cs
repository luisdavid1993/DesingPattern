/// <summary>
/// BEHAVIORAL
/// Is a plan of action designed to achive a specific goal, we can replace it at any time
/// Define a family of algorithms independenly from that client use it.
/// </summary>

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        CustomerBase customer = new CustomerBase(new DiscountBillAmount());
        customer.CustomerName = "Test";
        customer.PhoneNumber = "12156165";
        customer.BillDate= DateTime.Now;
        customer.BillAmount = 1000;
        decimal finalCost = customer.ActualCost();

        Console.WriteLine(finalCost);

        Console.ReadLine();
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
    decimal ActualCost(); //ActualCost = BillAmount - discount + extra charge 
}

public class CustomerBase : ICustomer
{

    private IDiscount discount;

    public int Id { get; set; }
    public string CustomerType { get; set; }
    public string CustomerName { get; set; }
    public string PhoneNumber { get; set; }
    public decimal BillAmount { get; set; }
    public DateTime BillDate { get; set; }
    public string Address { get; set; }

    public CustomerBase()
    {

    }
    public CustomerBase(IDiscount discount)
    {
        this.discount = discount;
    }


    public decimal ActualCost()
    {
        return BillAmount - discount.Calculate(this);
    }

}
public interface IDiscount
{
    decimal Calculate(ICustomer obj);
}

/// <summary>
/// Discount whent the bill amount is greater than 10.000
/// </summary>
public class DiscountBillAmount : IDiscount
{
    public decimal Calculate(ICustomer obj)
    {
        if (obj.BillAmount > 10000)
            return obj.BillAmount * Convert.ToDecimal(0.02);
        else
            return obj.BillAmount * Convert.ToDecimal(0.01);
    }
}

/// <summary>
/// discount on days Sunday or Saturday
/// </summary>
public class DiscountSatSun : IDiscount
{
    public decimal Calculate(ICustomer obj)
    {
        if (obj.BillDate.DayOfWeek == DayOfWeek.Saturday || obj.BillDate.DayOfWeek == DayOfWeek.Sunday)
            return obj.BillAmount * Convert.ToDecimal(0.01);
        else
            return obj.BillAmount * Convert.ToDecimal(0.005);
    }
}

public class DiscountNotAvalible : IDiscount  //Design pattern :- NULL pattern (when it do not need a vale, a defalut value)
{
    public decimal Calculate(ICustomer obj)
    {
        return 0;
    }
}