using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public abstract class ReportBuilder
    {
        protected  Report _report;
        public void CreateReport()
        {
            _report = new Report();
        }
        public abstract void SetReportType();
        public abstract void SetReportHeader();
        public abstract void SetReportFooter();

        public virtual Report GetReport()
        {
            return _report;
        }

    }
}
