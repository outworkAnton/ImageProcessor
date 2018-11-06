using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchwabenCode.QuickIO;

namespace DataAccess
{
    static class FileToModelConverter
    {
        public static ProductImage ConvertToModel(QuickIOFileInfo file)
        {
            return new ProductImage(file.Name, file.FullName);
        }

        public static IReadOnlyCollection<ProductImage> ConvertToModels(IReadOnlyCollection<QuickIOFileInfo> files)
        {
            return files.Select(x => new ProductImage(x.Name, x.FullName)).ToArray();
        }

        public static QuickIOFileInfo ConvertToFile(ProductImage productImage)
        {
            return new QuickIOFileInfo(productImage.Path);
        }

        public static IReadOnlyCollection<QuickIOFileInfo> ConvertToFiles(IReadOnlyCollection<ProductImage> productImages)
        {
            return productImages.Select(x => new QuickIOFileInfo(x.Path)).ToArray();
        }
    }
}
