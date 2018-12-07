using BusinessLogic.Contract.Interfaces;
using BusinessLogic.Contract.Models;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ProcessImagesService : IProcessImagesService
    {
        public string GetImageTag(string path)
        {
            return string.Join(",", ShellFile.FromFilePath(path).Properties.System.Keywords.Value);
        }

        public void Process(IReadOnlyCollection<ProductImage> imagesForProcess)
        {
            try
            {
                foreach (var productImage in imagesForProcess)
                {
                    var tags = ShellFile.FromFilePath(productImage.Path).Properties.System.Keywords.Value;
                    var image = Image.FromFile(productImage.Path);
                    var footerHeight = 72;
                    Bitmap newImage = new Bitmap(image.Width, image.Height + footerHeight);
                    var destRect = new Rectangle(0, 0, image.Width, image.Height);
                    newImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
                    using (Graphics g = Graphics.FromImage(newImage))
                    {
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
                        var text = productImage.Count.ToString();
                        var font = new Font("Calibri", 72F, FontStyle.Regular);
                        var drawBrush = new SolidBrush(Color.Black);
                        var format = new StringFormat()
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        };
                        var rect = new RectangleF(0, image.Height, image.Width, footerHeight);
                        g.DrawString(text, font, drawBrush, rect, format);
                    }
                    image.Dispose();
                    newImage.Save(productImage.Path, ImageFormat.Jpeg);
                    ShellFile.FromFilePath(productImage.Path).Properties.System.Keywords.Value = tags;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
