using CompositePattern;
/// <summary>
/// STRUCTURAL
/// Treating difference objects in a similar fashion
/// Is just an Interface implementation
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        List<IUserInterface> lstInterface = new List<IUserInterface>();
        lstInterface.Add(new Circule());
        lstInterface.Add(new Square());

        foreach (var item in lstInterface)
        {
            item.Draw();
        }


        //Calling the second Composite Way


        Product ram = new SimpleProduct("Ram 16 gb", 7000);
        Product processor = new SimpleProduct("Intel core 7", 17000);
        Product videoCard = new SimpleProduct("nVidia gtx 1050", 85000);
        Product keyBoard = new SimpleProduct("Teclado Dell", 300);
        Product mouse = new SimpleProduct("Mouse Dell", 300);
        Product rig = new SimpleProduct("Torre hp", 3000);
        Product led = new SimpleProduct("Led Lg", 4000);

        Product gamingKit = new CompositeProduct("Computador gamer básico");
        gamingKit.Add(ram);
        gamingKit.Add(processor);
        gamingKit.Add(videoCard);
        gamingKit.Add(keyBoard);
        gamingKit.Add(mouse);
        gamingKit.Add(rig);
        gamingKit.Add(led);

        Console.WriteLine(ram.GetPrice());
        Console.ReadLine();
    }


}

public interface IUserInterface
{
    void Draw();
}

public class Circule : IUserInterface
{
    public void Draw()
    {
        Console.WriteLine("Drawing a circule");
    }
}
public class Square : IUserInterface
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Square");
    }
}