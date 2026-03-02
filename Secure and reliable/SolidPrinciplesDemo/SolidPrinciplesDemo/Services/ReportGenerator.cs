using SolidPrinciplesDemo.Models;

namespace SolidPrinciplesDemo.Services
{
    public class ReportGenerator
    {
        public Report Generate()
        {
            return new Report
            {
                Content = "Monthly Sales Report"
            };
        }
    }
}
