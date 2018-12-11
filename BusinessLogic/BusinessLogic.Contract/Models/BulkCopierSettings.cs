using System.Drawing;
using System.Drawing.Printing;
using System.Linq;

namespace BusinessLogic.Contract.Models
{
    public class BulkCopierSettings
    {
        private int _pageColumns = 5;
        private int _pageRows = 5;

        public string SourcePath { get; set; }
        public Size FormSize { get; set; } = new Size(650, 550);
        public Point FormLocation { get; set; } = new Point(0, 0);
        public int PageColumns
        {
            get => _pageColumns;
            set => _pageColumns = value > 1 ? value : 1;
        }
        public int PageRows
        {
            get => _pageRows;
            set => _pageRows = value > 1 ? value : 1;
        }
        public bool DrawGridLines { get; set; } = true;
        public Margins PageMargins { get; set; } = new Margins(100, 100, 100, 100);
        public bool PageLandscape { get; set; }
        public PaperSize PageSize { get; set; } = new PaperSize() { RawKind = (int)PaperKind.A4, PaperName = "A4" };
        public string PrinterName { get; set; } = GetDefaultPrinterName();

        private static string GetDefaultPrinterName() => PrinterSettings.InstalledPrinters
                .OfType<string>()
                .Select(p => new PrinterSettings { PrinterName = p })
                .Where(ps => ps.IsValid && ps.IsDefaultPrinter)
                .Select(pn => pn.PrinterName)
                .FirstOrDefault();
    }
}
