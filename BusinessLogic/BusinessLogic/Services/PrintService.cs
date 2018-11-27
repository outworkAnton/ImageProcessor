using BusinessLogic.Contract.Interfaces;
using BusinessLogic.Contract.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
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
                    .Clone(_prinableArea, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                var canvas = Graphics.FromImage(grid);

                for (int row = 0; row < _rows - 1; row++)
                {
                    var currentPoint = new PointF(startPoint.X, startPoint.Y + (row * rowHeight));
                    var frame = new RectangleF(currentPoint, cellSize);

                    for (int column = 0; column < _columns - 1; column++)
                    {
                        currentPoint = new PointF(startPoint.X + (column * columnWidth), currentPoint.Y);
                        frame = new RectangleF(currentPoint, cellSize);

                        try
                        {
                            var productImage = _images.ElementAt(0);
                            var image = Image.FromFile(productImage.Path);
                            if (productImage.Count > 1)
                            {
                                Bitmap newImage = new Bitmap(image.Width, image.Height + 20);
                                using (Graphics g = Graphics.FromImage(newImage))
                                {
                                    Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
                                    g.DrawImageUnscaledAndClipped(image, rect);
                                    g.FillRectangle(new SolidBrush(Color.White), 0, image.Height, newImage.Width, 20);
                                    Font font = new Font("Calibri", 72);
                                    PointF point = new PointF(image.Width/2, 0);
                                    g.DrawString(productImage.Count.ToString(), font, Brushes.Black, point);
                                }
                                canvas.DrawImage(newImage, frame);
                            }
                            else
                            {
                                canvas.DrawImage(image, frame);
                            }
                            _images.RemoveAt(0);
                        }
                        catch
                        {
                            break;
                        }
                    }
                }
                _pages.Add(grid); 
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
