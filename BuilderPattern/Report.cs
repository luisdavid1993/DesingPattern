using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class Report
    {
        public string? ReportType { get; set; }
        public string? ReportHeader { get; set; }
        public string? ReportFooter { get; set; }

        public virtual string DisplayReport()
        {
            return  $"{ReportType} --- {ReportHeader} -- {ReportFooter}";
        }
    }
}
