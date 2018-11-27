using BusinessLogic.Contract.Interfaces;
using BusinessLogic.Contract.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ProcessImagesService : IProcessImagesService
    {
        public void Process(IReadOnlyCollection<ProductImage> imagesForProcess)
        {
            foreach (var productImage in imagesForProcess)
            {
                var image = Image.FromFile(productImage.Path);
                var footerHeight = 50;
                Bitmap newImage = new Bitmap(image.Width, image.Height + footerHeight);
                var destRect = new Rectangle(0, 0, newImage.Width, newImage.Height);
                newImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
                using (Graphics g = Graphics.FromImage(newImage))
                {
                    g.CompositingMode = CompositingMode.SourceCopy;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    using (var wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        g.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                    }

                    g.FillRectangle(new SolidBrush(Color.White), 0, image.Height, newImage.Width, footerHeight);
                    Font font = new Font("Calibri", 72);
                    PointF point = new PointF(newImage.Width / 2, newImage.Height - footerHeight);
                    g.DrawString(productImage.Count.ToString(), font, Brushes.Black, point);
                }
                newImage.Save(productImage.Path);
            }
        }
    }
}
