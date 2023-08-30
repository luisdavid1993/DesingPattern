using System.Collections;
using System.Reflection.Metadata.Ecma335;
/// <summary>
/// BEHAVIORAL
/// When just need to iterate over a list, do not allow add, remove end other method, just iterate. 
/// Enumerable or Enumerator encapsulate ADD, REMOVE methods.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Iterator iterator = new Iterator();
        iterator.FillObjects();

        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.Next());
        }

    }
}
public class Customer
{
    public string CustomerName { get; set; }
    public string CustomerCode { get; set; }

    public override string ToString()
    {
        return $"{CustomerName} -- {CustomerCode}";
    }
}

public class Iterator
{
    private int currentIndex = 0;
    private ArrayList objArray = new ArrayList();

    public void FillObjects()
    {
        Customer customer = new Customer();
        customer.CustomerName = "Luis David";
        customer.CustomerCode = "2023";
        objArray.Add(customer);

        customer = new Customer();
        customer.CustomerName = "Mariangeles";
        customer.CustomerCode = "2025";
        objArray.Add(customer);
    }

    public Customer GetByIndex(int index)
    {
        if (index > objArray.Count || index < 0)
            throw new IndexOutOfRangeException();

        currentIndex = index;
        currentIndex++;
        return (Customer)objArray[index];
    }

    public Customer Preview()
    {
        int tempIndex = currentIndex;
        tempIndex--;
        return GetByIndex(tempIndex);
    }
    public Customer Next()
    {
        return GetByIndex(currentIndex);
    }

    public Customer GetFist() 
    {
        return GetByIndex(0);
    }

    public Customer GetLast()
    {
       return GetByIndex(objArray.Count);
    }

    public bool HasNext()
    {
        int tempIndex = currentIndex + 1;
        if (objArray.Count >= tempIndex)
            return true;
        return false;
    }
}

