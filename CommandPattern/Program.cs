
using System.Collections;
/// <summary>
/// BEHAVIORAL
/// Allows a request to exist as an object. Is like ctr+c or  ctr+v created in a class
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Invoker invoker = new Invoker();
        AExecute execCommand = invoker.GetCommand("Print");
        execCommand.Execute(); 
    }
}

public class Invoker
{ 
  private ArrayList objArrayList = new ArrayList();
    public Invoker()
    {
        objArrayList.Add(new ExecuteOpen());
        objArrayList.Add(new ExecuteClose());
        objArrayList.Add(new ExecutePrint());
    }

    public AExecute GetCommand(string command)
    {
        foreach (var item in objArrayList)
        {
            AExecute objExecute = (AExecute)item;
            if (objExecute.srtCommand == command)
                return objExecute;
        }
        return null;
    }
}

public abstract class AExecute
{
    public string srtCommand { get; set; }
    public abstract void Execute();
}

public class ExecutePrint : AExecute
{
    public ExecutePrint()
    {
        srtCommand = "Print";
    }
    public override void Execute()
    {
        Console.WriteLine($"Command {srtCommand}");
    }
}

public class ExecuteOpen : AExecute
{
    public ExecuteOpen()
    {
        srtCommand = "Open";
    }
    public override void Execute()
    {
        Console.WriteLine($"Command {srtCommand}");
    }
}

public class ExecuteClose : AExecute
{
    public ExecuteClose()
    {
        srtCommand = "Close";
    }
    public override void Execute()
    {
        Console.WriteLine($"Command {srtCommand}");
    }
}