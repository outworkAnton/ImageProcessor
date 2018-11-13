using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Contract.Models;
using SchwabenCode.QuickIO;

namespace BusinessLogic
{
    internal static class FileToModelConverter
    {
        public static ProductImage ConvertToModel(QuickIOFileInfo file)
        {
            return new ProductImage(file.Name, file.FullName);
        }

        public static IReadOnlyCollection<ProductImage> ConvertToModels(IEnumerable<QuickIOFileInfo> files)
        {
            return files.Select(x => new ProductImage(x.Name, x.FullName)).ToArray();
        }

        public static QuickIOFileInfo ConvertToFile(ProductImage productImage)
        {
            return new QuickIOFileInfo(productImage.Path);
        }

        public static IReadOnlyCollection<QuickIOFileInfo> ConvertToFiles(IEnumerable<ProductImage> productImages)
        {
            return productImages.Select(x => new QuickIOFileInfo(x.Path)).ToArray();
        }
    }
}
