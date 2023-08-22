/// <summary>
/// CREATIONAL
/// Only one instance of the object share for the hole application. Global Data.
//No client can create an instance of this object from outside.
//Static keywork create only one instance of one object.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Singleton singleton = Singleton.Instance;
        singleton.HitCount();
        int count = singleton.HitCount();
        Console.WriteLine(count);
    }
}

public sealed class Singleton
{
    private Singleton() { }
    private static readonly object lockObject = new object();
    private static Singleton instance;
    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
            }
            return instance;
        }
    }
   

    private int Counter { get; set; }

    public int HitCount()
    { 
        return ++Counter;
    }

    public int GetHitCount()
    {
        return Counter;
    }
}