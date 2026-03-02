using SolidPrinciplesDemo.Interfaces;

namespace SolidPrinciplesDemo.Services
{
    public class PdfDocument : IDocument
    {
        public void Open()
        {
            System.Console.WriteLine("Opening PDF document");
        }
    }
}
