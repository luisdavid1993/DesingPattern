using System.Text;
using System.Text.RegularExpressions;
/// <summary>
/// BEHAVIORAL
/// Allow to interpret grammar into code solutions (xml, json… parse) 
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Context context = new Context("DD-MM-YYYY");
        Format format = new Format(context);
        string formatResult = format.Formater();

        Console.WriteLine(formatResult);

        Console.ReadLine(); 
    }
}

public  class Format
{
    private Dictionary<string, AbstractExpression> keys;
    Context context;
    StringBuilder builder;
    public Format(Context _expresion)
    {
        context = _expresion;
        keys = new Dictionary<string, AbstractExpression>();
        keys.Add("YYYY", new YearExpression());
        keys.Add("MM", new MonthExpression());
        keys.Add("DD", new DayExpression());
        keys.Add("-", new Separator());
        builder = new StringBuilder();
    }

    public string Formater()
    {
        string pattern = "(-)";
        string[] strings = Regex.Split(context.Exprression, pattern);
       
        foreach (var item in strings)
        {
            string temp = keys[item].Evaluate(context);
            builder.Append(temp);
        }

        return builder.ToString();
    }
}

public class Context
{
    public string Exprression;

    public Context(string _expression)
    {
        this.Exprression = _expression;
    }
}
public abstract class AbstractExpression
{
    public abstract string Evaluate(Context context);
}

public class YearExpression : AbstractExpression
{
    public override string Evaluate(Context context)
    {
        return DateTime.Now.Year.ToString();
    }
}

public class MonthExpression : AbstractExpression
{
    public override string Evaluate(Context context)
    {
        return  DateTime.Now.Month.ToString();
    }
}

public class DayExpression : AbstractExpression
{
    public override string Evaluate(Context context)
    {
        return  DateTime.Now.Day.ToString();
    }
}

public class Separator : AbstractExpression
{
    public override string Evaluate(Context context)
    {
        return "-";
    }
}