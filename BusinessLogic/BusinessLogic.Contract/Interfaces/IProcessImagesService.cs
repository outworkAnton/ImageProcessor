using System.Collections.Generic;
using BusinessLogic.Contract.Models;

namespace BusinessLogic.Contract.Interfaces
{
    public interface IProcessImagesService
    {
        void Process(IReadOnlyCollection<ProductImage> imagesForProcess);
        string GetImageTag(string path);
    }
}