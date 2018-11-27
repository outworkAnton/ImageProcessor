using BusinessLogic.Contract.Interfaces;
using BusinessLogic.Contract.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;

namespace BusinessLogic.Services
{
    public class PrintService : IPrintService
    {
        private RectangleF _prinableArea = new RectangleF();
        private List<ProductImage> _images = new List<ProductImage>();
        private int _columns;
        private int _rows;
        private string _orderId = string.Empty;

        private List<Image> _pages = new List<Image>();

        public Image GetPage()
        {
            if (!_pages.Any())
            {
                GeneratePages();
            }
            var tmpImg = _pages.ElementAt(0).Clone() as Image;
            _pages.RemoveAt(0);
            return tmpImg;
        }

        private void GeneratePages()
        {
            var imagesPerPage = (int)Math.Ceiling((decimal)_images.Count / (_columns * _rows));
            var header = new RectangleF(_prinableArea.X, _prinableArea.Y, _prinableArea.Width, 20);
            var footer = new RectangleF(_prinableArea.Left, _prinableArea.Bottom - 10, _prinableArea.Width, 10);
            var columnWidth = _prinableArea.Width / _columns;
            var rowHeight = (_prinableArea.Height / _rows) - (header.Height + footer.Height);
            var cellSize = new SizeF(columnWidth - 5, rowHeight - 5);
            var startPoint = new PointF(_prinableArea.X + 5, _prinableArea.Y + header.Height + 5);

            for (var page = 1; page <= imagesPerPage; page++)
            {
                var grid = new Bitmap((int)Math.Ceiling(_prinableArea.Width), (int)Math.Ceiling(_prinableArea.Height))
                    .Clone(_prinableArea, PixelFormat.Format32bppArgb);
                var canvas = Graphics.FromImage(grid);

                for (int row = 0; row < _rows - 1; row++)
                {
                    var currentPoint = new PointF(startPoint.X, startPoint.Y + (row * rowHeight));
                    var frame = new RectangleF(currentPoint, cellSize);

                    for (int column = 0; column < _columns - 1; column++)
                    {
                        currentPoint = new PointF(startPoint.X + (column * columnWidth), currentPoint.Y);
                        frame = new RectangleF(currentPoint, cellSize);

                        if (_images.Any())
                        {
                            var productImage = _images.ElementAt(0);
                            var image = ScaleImage(Image.FromFile(productImage.Path), (int)Math.Ceiling(frame.Width));
                            canvas.DrawImage(image, currentPoint);
                            _images.RemoveAt(0);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                _pages.Add(grid); 
            }
        }

        private Image ScaleImage(Image source, int width)
        {
            try
            {
                double q = (double)source.Width / width;
                int height = (int)Math.Round(source.Height / q);

                var destRect = new Rectangle(0, 0, width, height);
                var dest = new Bitmap(width, height);
                dest.SetResolution(source.HorizontalResolution, source.VerticalResolution);
                using (var graphics = Graphics.FromImage(dest))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    using (var wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(source, destRect, 0, 0, source.Width, source.Height, GraphicsUnit.Pixel, wrapMode);
                    }
                }
                return dest;
            }
            catch
            {
                return source;
            }
        }

        public bool HasNextPage()
        {
            return _pages.Any();
        }

        public void ResetPrintSettings()
        {
            _pages = null;
            _prinableArea = new RectangleF();
            _images = new List<ProductImage>();
            _columns = 0;
            _rows = 0;
            _orderId = string.Empty;
        }

        public void SetPrintSettings(PrintDocument printDocument, IReadOnlyCollection<ProductImage> processedImages, int columnsCount, int rowsCount)
        {
            _prinableArea = printDocument.DefaultPageSettings.PrintableArea;
            _images = processedImages.ToList();
            _columns = columnsCount;
            _rows = rowsCount;
            _orderId = printDocument.DocumentName;
        }
    }
}
