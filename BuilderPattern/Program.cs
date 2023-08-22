using BuilderPattern;
/// <summary>
/// CREATIONAL
/// Builder Pattern
/// Help us to separate the construction of a complex object from its representation. 
/// The same construction process can create difference representations. 
/// Common steps for creating difference objects.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

       
        Report report; // the entity
        Director director = new Director(); // take those individual processes from the builder and defines the sequence to build the product. 


        // PDF Report construction -----------------
        ReportPDF reportPDF = new ReportPDF(); // Is responsible for defining the construction process for individual parts 
        report = director.MakeReport(reportPDF);
        Console.WriteLine(report.DisplayReport());

        //Excel report construnction ------------------
        ReportExcel reportExcel = new ReportExcel(); // Is responsible for defining the construction process for individual parts 
        report = director.MakeReport(reportExcel);
        Console.WriteLine(report.DisplayReport());
    }
}