using System.Drawing;
using System.Drawing.Printing;

namespace BusinessLogic.Contract.Models
{
    public class BulkCopierSettings
    {
        public string SourcePath { get; set; }
        public Size FormSize { get; set; } = new Size(600, 500);
        public Point FormLocation { get; set; } = new Point(0, 0);
        public int PageColumns { get; set; } = 5;
        public int PageRows { get; set; } = 5;
        public bool DrawGridLines { get; set; } = true;
        public Margins PageMargins { get; set; } = new Margins(100, 100, 100, 100);
        public bool PageLandscape { get; set; }
        public PaperSize PageSize { get; set; } = new PaperSize() { RawKind = (int)PaperKind.A4 };
        public string PrinterName { get; set; } = GetDefaultPrinterName();

        private static string GetDefaultPrinterName()
        {
            foreach (string printerName in PrinterSettings.InstalledPrinters)
            {
                var printer = new PrinterSettings
                {
                    PrinterName = printerName
                };
                if (printer.IsValid && printer.IsDefaultPrinter)
                {
                    return printerName;
                }
            }
            return string.Empty;
        }
    }
}
