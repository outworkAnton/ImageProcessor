using BulkCopier.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchwabenCode.QuickIO;
using BulkCopier.Helpers;

namespace BulkCopier.Processors
{
    internal class CopyFilesProcessor : IProcessor
    {
        private readonly IReadOnlyCollection<ProductImage> _productImages;
        private readonly QuickIODirectoryInfo _destinationDirectory;

        public CopyFilesProcessor(IReadOnlyCollection<ProductImage> productImages, string destinationDirectory)
        {
            _productImages = productImages;
            _destinationDirectory = new QuickIODirectoryInfo(destinationDirectory);
        }

        public async Task ProcessCollection()
        {
            foreach (var item in _productImages.Where(p => !p.Processed))
            {
                await ProcessItem(item.Id).ConfigureAwait(false);
            }
        }

        public async Task ProcessItem(string id)
        {
            var item = _productImages
                .Where(p => p.Id == id)
                .Select(f => FileToModelConverter.ConvertToFile(f))
                .FirstOrDefault();
            await QuickIOFile.CopyToDirectoryAsync(item, _destinationDirectory).ConfigureAwait(false);
        }
    }
}
