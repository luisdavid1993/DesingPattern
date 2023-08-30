/// <summary>
/// STRUCTURAL
/// Is used when we have series of processing which will be handle by a series of handler logic
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Proccess1 proccess1 = new Proccess1();
        Proccess2 proccess2 = new Proccess2();
        Proccess3 proccess3 = new Proccess3();

        proccess1.SetProccess(proccess2);
        proccess2.SetProccess(proccess3);
        proccess1.RunProccess();


        Console.ReadLine();
    }
}

public abstract class AProccess
{
    // is a Link to the next handler
    protected AProccess aProccess;
    public void SetProccess(AProccess _aProccess)
    {
        this.aProccess = _aProccess;
    }

    public abstract void RunProccess();
}

public class Proccess1 : AProccess
{
    public override void RunProccess()
    {
        Console.WriteLine("Running proccess 1");
        if (aProccess != null)
            aProccess.RunProccess();
    }
}

public class Proccess2 : AProccess
{
    public override void RunProccess()
    {
        Console.WriteLine("Running proccess 2");
        if (aProccess != null)
            aProccess.RunProccess();
    }
}

public class Proccess3 : AProccess
{
    public override void RunProccess()
    {
        Console.WriteLine("Running proccess 3");
        if (aProccess != null)
            aProccess.RunProccess();
    }
}