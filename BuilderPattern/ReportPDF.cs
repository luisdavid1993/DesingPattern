using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    // take those individual processes from the builder and defines the sequence to build the product.
    public class ReportPDF : ReportBuilder
    {
        public override void SetReportType()
        {
            _report.ReportType = "PDF";
        }
        public override void SetReportHeader()
        {
            _report.ReportHeader = "This the PDF Header";
        }
        public override void SetReportFooter()
        {
            _report.ReportFooter = "footer PDF";
        }

        

       
    }
}
