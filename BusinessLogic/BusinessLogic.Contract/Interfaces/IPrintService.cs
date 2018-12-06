using BusinessLogic.Contract.Models;
using System.Drawing.Printing;
using System.Drawing;
using System.Collections.Generic;

namespace BusinessLogic.Contract.Interfaces
{
    public interface IPrintService
    {
        Image GetPage();
        bool HasNextPage();
        void SetPrintSettings(PrintDocument printDocument,
            IReadOnlyCollection<ProductImage> processedImages,
            BulkCopierSettings settings);
        void ResetPrintSettings();
    }
}