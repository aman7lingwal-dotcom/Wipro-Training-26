using SolidPrinciplesDemo.Interfaces;

namespace SolidPrinciplesDemo.Services
{
    public class PdfFormatter : IReportFormatter
    {
        public string Format(string content)
        {
            return "PDF Format: " + content;
        }
    }
}
