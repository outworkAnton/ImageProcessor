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
        private RectangleF _printableArea = new RectangleF();
        private List<ProductImage> _images = new List<ProductImage>();
        private int _columns;
        private int _rows;
        private string _orderId = string.Empty;

        private List<Image> _pages = new List<Image>();

        public Image GetPage()
        {
            if (_pages.Count == 0)
            {
                GeneratePages();
            }
            var tmpImg = _pages[0].Clone() as Image;
            _pages.RemoveAt(0);
            return tmpImg;
        }

        private void GeneratePages()
        {
            const float pageHeaderHeight = 35F;
            const float pageHeaderFontSize = 20F;

            const float pageFooterHeight = 25F;
            const float pageFooterFontSize = 10F;

            const float cellPadding = 2.5F;
            const float cellHeaderHeight = 20F;
            const float cellHeaderFontSize = 10F;
            const float pageFields = 30F;

            try
            {
                var pagesCount = (int)Math.Ceiling((decimal)_images.Count / (_columns * _rows));
                var header = new RectangleF(_printableArea.Left + pageFields, _printableArea.Top + pageFields, _printableArea.Width, pageHeaderHeight);
                var footer = new RectangleF(_printableArea.Left + pageFields, _printableArea.Bottom - (pageFields + pageFooterHeight), _printableArea.Width, pageFooterHeight);
                var columnWidth = (_printableArea.Width - (pageFields * 2)) / _columns;
                var rowSize = new SizeF(_printableArea.Width - (pageFields * 2), (_printableArea.Height - (header.Height + footer.Height + (pageFields * 2))) / _rows);
                var cellSize = new SizeF(columnWidth - (cellPadding * 2), rowSize.Height - (cellPadding * 2));
                var startPoint = new PointF(_printableArea.Left + pageFields, _printableArea.Top + header.Height + pageFields);

                for (var page = 1; page <= pagesCount; page++)
                {
                    var pageGrid = new Bitmap((int)Math.Floor(_printableArea.Width), (int)Math.Floor(_printableArea.Height));
                    using (var pageCanvas = Graphics.FromImage(pageGrid))
                    {
                        EnableHQMode(pageCanvas);

                        DrawHeaderOrFooter("Заказ № " + _orderId, pageHeaderFontSize, pageCanvas, header);

                        for (int row = 0; row < _rows; row++)
                        {
                            if (_images.Count > 0)
                            {
                                var rowPoint = new PointF(startPoint.X, startPoint.Y + (row * rowSize.Height));
                                var rowFrame = new RectangleF(rowPoint, rowSize);
                                var rowGrid = new Bitmap((int)Math.Floor(rowSize.Width), (int)Math.Floor(rowSize.Height));
                                var rowCanvas = Graphics.FromImage(rowGrid);
                                if (row > 0) pageCanvas.DrawLine(new Pen(Brushes.DarkGray), rowPoint, new PointF(_printableArea.Right - pageFields, rowPoint.Y));
                                EnableHQMode(rowCanvas);
                                rowPoint = new PointF(rowPoint.X, rowPoint.Y + cellPadding);

                                for (int column = 0; column < _columns; column++)
                                {
                                    if (_images.Count > 0)
                                    {
                                        var cellPoint = new PointF((column * columnWidth) + cellPadding, cellPadding);
                                        var cellFrame = new RectangleF(cellPoint, cellSize);
                                        var cellHeaderSize = new SizeF(cellFrame.Width, cellHeaderHeight);
                                        var cellHeader = new RectangleF(new PointF(2.5F, 2.5F), cellHeaderSize);
                                        var cellGrid = new Bitmap((int)Math.Floor(cellSize.Width), (int)Math.Floor(cellSize.Height));
                                        var cellCanvas = Graphics.FromImage(cellGrid);
                                        if (column > 0) pageCanvas.DrawLine(
                                            new Pen(Brushes.DarkGray),
                                            new PointF((column * columnWidth) + pageFields, _printableArea.Top + pageHeaderHeight + pageFields),
                                            new PointF((column * columnWidth) + pageFields, _printableArea.Bottom - pageHeaderHeight - pageFields));

                                        EnableHQMode(cellCanvas);

                                        var productImage = _images[0];
                                        DrawHeaderOrFooter(productImage.Id, cellHeaderFontSize, cellCanvas, cellHeader);
                                        var image = ScaleImage(Image.FromFile(productImage.Path), (int)Math.Floor(cellFrame.Width), (int)Math.Floor(cellFrame.Height - cellHeaderSize.Height));
                                        var centerCellWidthPoint = (cellFrame.Width - image.Width) / 2;
                                        cellCanvas.DrawImage(image, new PointF(centerCellWidthPoint, cellHeaderHeight));
                                        _images.RemoveAt(0);
                                        rowCanvas.DrawImage(cellGrid, cellFrame);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                rowPoint = new PointF(rowPoint.X, rowPoint.Y - cellPadding);
                                pageCanvas.DrawImage(rowGrid, rowFrame);
                            }
                            else
                            {
                                break;
                            }
                        }
                        DrawHeaderOrFooter("Страница " + page.ToString(), pageFooterFontSize, pageCanvas, footer);
                    }
                    _pages.Add(pageGrid);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void DrawHeaderOrFooter(string content, float fontSize, Graphics canvas, RectangleF frame)
        {
            var font = new Font("Calibri", fontSize);
            var brush = new SolidBrush(Color.Black);
            var format = new StringFormat()
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };
            canvas.DrawString(content, font, brush, frame, format);
        }

        private static void EnableHQMode(Graphics pageCanvas)
        {
            pageCanvas.CompositingQuality = CompositingQuality.HighQuality;
            pageCanvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
            pageCanvas.SmoothingMode = SmoothingMode.HighQuality;
            pageCanvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
        }

        private Image ScaleImage(Image source, int width, int height)
        {
            try
            {
                double q;
                if (source.Width > source.Height)
                {
                    q = (double)source.Width / width;
                    height = (int)Math.Round(source.Height / q);
                }
                else
                {
                    q = (double)source.Height / height;
                    width = (int)Math.Round(source.Width / q);
                }
                

                var destRect = new Rectangle(0, 0, width, height);
                var dest = new Bitmap(width, height);
                dest.SetResolution(source.HorizontalResolution, source.VerticalResolution);
                using (var graphics = Graphics.FromImage(dest))
                {
                    EnableHQMode(graphics);

                    using (var wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(source, destRect, 0, 0, source.Width, source.Height, GraphicsUnit.Pixel, wrapMode);
                    }
                }
                return dest;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public bool HasNextPage() => _pages.Count > 0;

        public void ResetPrintSettings()
        {
            _pages = new List<Image>();
            _printableArea = new RectangleF();
            _images = new List<ProductImage>();
            _columns = 0;
            _rows = 0;
            _orderId = string.Empty;
        }

        public void SetPrintSettings(PrintDocument printDocument, IReadOnlyCollection<ProductImage> processedImages, int columnsCount, int rowsCount)
        {
            _printableArea = printDocument.DefaultPageSettings.PrintableArea;
            _images = processedImages.ToList();
            _columns = columnsCount;
            _rows = rowsCount;
            _orderId = printDocument.DocumentName;
        }
    }
}
