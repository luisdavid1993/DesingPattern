using CompositePattern;
/// <summary>
/// STRUCTURAL
/// Treating difference objects in a similar fashion way
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
        Console.WriteLine(gamingKit.GetPrice());

        //Calling the tree Composite Way
        AProduct ram2 = new SimpleProduct2("Ram 2 16 gb", 7000);
        AProduct processor2 = new SimpleProduct2("Intel core 7", 17000);
        AProduct videoCard2 = new SimpleProduct2("nVidia gtx 1050", 85000);
        AProduct keyBoard2 = new SimpleProduct2("Teclado Dell", 300);
        AProduct mouse2 = new SimpleProduct2("Mouse Dell", 300);
        AProduct rig2 = new SimpleProduct2("Torre hp", 3000);
        AProduct led2 = new SimpleProduct2("Led Lg", 4000);

        Console.WriteLine(ram.GetPrice());

        ACompositeProduct gamingKit2 =new  CompositeProduct2("Computador gamer básico 2");
        gamingKit2.Add(ram2);
        gamingKit2.Add(processor2);
        gamingKit2.Add(videoCard2);
        gamingKit2.Add(keyBoard2);
        gamingKit2.Add(mouse2);
        gamingKit2.Add(rig2);
        gamingKit2.Add(led2);

        Console.WriteLine(gamingKit2.GetPrice());

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