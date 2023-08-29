/// <summary>
/// STRUCTURAL
/// It is like a pointer to some outside data 
/// </summary>
/// <param name="args"></param>
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        ImageProxy proxy = new ActualImage();
        proxy.LoadImage();
        proxy.PrintImage();

        Console.ReadLine();

    }
}

public interface ImageProxy
{
    void LoadImage();
    void PrintImage();
}

public class ActualImage : ImageProxy
{
    string imagePath = "c://home//imageLD.jpg";
    public void LoadImage()
    {
        Console.WriteLine($"Load image {Path.GetFileName(imagePath)}");
    }

    public void PrintImage()
    {
        Console.WriteLine($"Pinting image {Path.GetFileName(imagePath)}");
    }
}
