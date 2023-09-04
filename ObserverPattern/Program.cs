
using System.Collections;
using System.Runtime.InteropServices;
/// <summary>
/// BEHAVIORAL
/// Helps us to communicate between parent class and its associated or dependent class. 
/// By a condition sending (Publisher) notifications to the observers (Subscribers)
/// Broadcasting 
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        decimal carPrice = 10000;

        Notifier notifier = new Notifier();

        INotification emailSubscriber = new EmailNotification();
        INotification smsSubscriber = new SMSNotification();

        notifier.AddNotifiers(emailSubscriber);
        notifier.AddNotifiers(smsSubscriber);

        Console.Write($"Set the price for this car :");
        decimal.TryParse(Console.ReadLine(), out carPrice);

        if (carPrice < 10000)
            notifier.NotifyAll();



        //My Own way
        Console.WriteLine("My own way to do it");
        Car car = new Car(notifier);
        car.Name= "Test";
        car.Model = "Camioneta doble cabina";
        car.Price = 5000;

    }
}

public interface INotification
{
    void Notify();
}

public class Notifier
{
    private ArrayList objList = new ArrayList();

    public void AddNotifiers(INotification notification)
    {
        objList.Add(notification);
    }
    public void RemoveNotifications(INotification notification)
    {
        objList.Remove(notification);
    }

    public void NotifyAll()
    {
        foreach (INotification item in objList)
        {
            item.Notify();
        }
    }
}

public class EmailNotification : INotification
{
    public void Notify()
    {
        Console.WriteLine("Email code notification executed");
    }
}
public class SMSNotification : INotification
{
    public void Notify()
    {
        Console.WriteLine("SMS code notification executed");
    }
}

public class EventNotification : INotification
{
    public void Notify()
    {
        Console.WriteLine("Event code notification executed");
    }
}
public class Car
{
    Notifier noty;

    public Car(Notifier _notifyer)
    { 
    this.noty = _notifyer;  
    }
    private decimal _price;
    public string Name { get; set; }
    public string Model { get; set; }
    public decimal Price
    {
        get { return _price; }
        set
        {
            if (value < 10000)
            {
                noty.NotifyAll();
            }
            _price = value;
        }
    }
}