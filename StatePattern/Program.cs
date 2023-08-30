/// <summary>
/// BEHAVIORAL
/// Allow an object to change its behavior depending on the current value of the object.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        clsState objState = new clsState();
        objState.PressSwich();
        Console.WriteLine(objState.GetState());

        Console.ReadLine();
    }
}

public class clsState
{
    enum BubleSate
    { 
      On = 1, 
      Off = 2
    }

    private BubleSate currentState = BubleSate.Off;
    public string GetState()
    { 
      return currentState.ToString();
    }

    public void PressSwich()
    { 
      if(currentState == BubleSate.Off)
            currentState = BubleSate.On;
      else if (currentState == BubleSate.On)
            currentState = BubleSate.Off;
    }
}