using SolidPrinciplesDemo.Models;
using System;

namespace SolidPrinciplesDemo.Services
{
    public class ReportSaver
    {
        public void Save(Report report)
        {
            Console.WriteLine("Report saved: " + report.Content);
        }
    }
}
