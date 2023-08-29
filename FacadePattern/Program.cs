internal class Program
{
    /// <summary>
    /// STRUCTURAL
    /// Allow to communicate with subsystems in a unified manner.
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Order order = new Order();
        order.PlaceOrder();
        Console.ReadLine();
    }
}
/// <summary>
/// this is the facade class, because unified the orders ones
/// </summary>
public class Order
{
    public void PlaceOrder()
    {
        Product product = new Product();
        Payment payment = new Payment();
        Invoice invoice = new Invoice();

        product.GetDetail();
        payment.PaymentOnline();
        invoice.PrintInvoice();

    }
}


public class Product
{
    public string GetDetail()
    {
        return "product details";
    }
}

public class Payment
{
    public void PaymentOnline()
    {

    }
}

public class Invoice
{
    public void PrintInvoice()
    { 
    }
}