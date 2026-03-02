using SolidPrinciplesDemo.Interfaces;
using SolidPrinciplesDemo.Models;

namespace SolidPrinciplesDemo.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportFormatter formatter;

        public ReportService(IReportFormatter formatter)
        {
            this.formatter = formatter;
        }

        public void ProcessReport(Report report)
        {
            var result = formatter.Format(report.Content);
            System.Console.WriteLine(result);
        }
    }
}
