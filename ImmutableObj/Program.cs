/// <summary>
/// Ones its are loaded cannot be changed internally or externally. (setting variable, singleton).
///ReadOnly allows to set the variable just ones time in the constructor.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Currency Euro = new Currency("Euro", "España");
    }
}



/// <summary>
/// esto es una simple prueba
/// </summary>
public class tester
{
    public readonly string Country;
    public const string City = "Valencia"; // just allow set at this time

    public tester()
    {
        Country = "Madrid";
    }

    //This method does not work because readonly just allow set the value in the constructor or when it is declared
    //public void SetCountry()
    //{
    //    Country = "Venezuela";
    //}
}

public class Currency
{
    private readonly string _CurrencyName;
    private readonly string _CountryName;

    public Currency(string currencyName, string countryName)
    {
        _CurrencyName = currencyName;
        _CountryName = countryName;
    }
    public string CurrencyName { get { return _CurrencyName; }  }
    public string CountryName { get { return _CountryName; } }

 
}