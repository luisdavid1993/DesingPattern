/// <summary>
/// STRUCTURAL
/// Helps to work in a unified way when we have incompatible interfaces from tree party. 
/// For example, we retrieved data in Json and xml format but we mapped this both types into a common object.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        ICollectionHandler handlerList = new HandleList();
        handlerList.Add("Hola");

        ICollectionHandler handlerStack = new HandleStack();
        handlerStack.Add("Hola");
    }
}

public interface ICollectionHandler
{ 
  void Add(string item);
}

public class HandleStack: ICollectionHandler
{
    Stack<string> stack;
    public HandleStack()
    {
        stack = new Stack<string>();
    }

    public void Add(string item)
    {
        stack.Push(item);
    }
}

public class HandleList: ICollectionHandler
{
    List<string> list;
    public HandleList()
    {
        list = new List<string>();
    }

    public void Add(string item)
    {
        list.Add(item);
    }
}