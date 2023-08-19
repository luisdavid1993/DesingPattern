using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    // take those individual processes from the builder and defines the sequence to build the product.
    public class ReportExcel : ReportBuilder
    {
        public override void SetReportType()
        {
            _report.ReportType = "Excel";
        }
        public override void SetReportHeader()
        {
            _report.ReportHeader = "Header for Excel";
        }
        public override void SetReportFooter()
        {
            _report.ReportFooter = "footer for Excel";
        }

       

       
    }
}
