using System.Collections.Generic;
using System.IO;
using System.Linq;
using BusinessLogic.Contract.Models;

namespace BusinessLogic
{
    internal static class FileToModelConverter
    {
        public static ProductImage ConvertToModel(FileInfo file)
        {
            var filename = Path.GetFileNameWithoutExtension(file.FullName);
            return new ProductImage(filename, file.FullName);
        }

        public static IReadOnlyCollection<ProductImage> ConvertToModels(IEnumerable<FileInfo> files)
        {
            return files.Select(x => new ProductImage(Path.GetFileNameWithoutExtension(x.FullName), x.FullName)).ToArray();
        }

        public static FileInfo ConvertToFile(ProductImage productImage)
        {
            return new FileInfo(productImage.Path);
        }

        public static IReadOnlyCollection<FileInfo> ConvertToFiles(IEnumerable<ProductImage> productImages)
        {
            return productImages.Select(x => new FileInfo(x.Path)).ToArray();
        }
    }
}
