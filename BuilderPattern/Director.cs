using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    // Is responsible for defining the construction process for individual parts 
    public class Director
    {
        public Report MakeReport(ReportBuilder builder)
        {
            builder.CreateReport();
            builder.SetReportType();
            builder.SetReportHeader();
            builder.SetReportFooter();
            return builder.GetReport();
        }
    }
}
