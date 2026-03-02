using SolidPrinciplesDemo.Interfaces;

namespace SolidPrinciplesDemo.Services
{
    public class DocumentFactory
    {
        public static IDocument Create(string type)
        {
            if (type == "PDF")
                return new PdfDocument();

            return null;
        }
    }
}
