/// <summary>
/// STRUCTURAL
/// Helps us to decouple the abstraction from implementation.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        IButonSwitch btn = new ButonSwitch();

        Fan fan = new Fan();
        btn.SetEquietment(fan);
        btn.Start();
        btn.Stop();

        TV tV = new TV();
        btn.SetEquietment(tV);
        btn.Start();
        btn.Stop();
    }
}
//Abstraction Interface, Use de implementation interface to decouple implementation
public interface IButonSwitch
{
    void Start();
    void Stop();
    void SetEquietment(IEquipment equipment);
}
public class ButonSwitch : IButonSwitch
{
    private IEquipment equipment;

    public void  SetEquietment (IEquipment equipment)
    {
        this.equipment = equipment;
    }

    public void Start()
    {
        equipment.Start();
    }

    public void Stop()
    {
        equipment.Stop();
    }
}



//Implementation Interface, allows us to decouple 
public interface IEquipment
{
    void Start();
    void Stop();
}

public class Fan : IEquipment
{
    public void Start()
    {
        Console.WriteLine("Fan start");
    }

    public void Stop()
    {
        Console.WriteLine("Fan stop");
    }
}

public class TV : IEquipment
{
    public void Start()
    {
        Console.WriteLine("TV start");
    }

    public void Stop()
    {
        Console.WriteLine("TV stop");
    }
}