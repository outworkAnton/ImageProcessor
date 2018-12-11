using BusinessLogic.Contract.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BusinessLogic.Contract.Interfaces
{
    public interface ICopyFilesService
    {
        int FindAllFiles();
        void SetSourceDirectory(string path);
        Task SetDestinationDirectory(string path);
        string GetDestinationDirectoryPath();
        Task<IReadOnlyCollection<ProductImage>> FindFiles(string filename, bool startsWith);
        Task<string> CopyFile(string filename);
        bool IsSourceDirectorySet();
        bool IsDestinationDirectorySet();
        void DeleteFile(string id);
        Task<ObservableCollection<ProductImage>> LoadFromDestinationDirectory();
        void SaveProcessedImagesList(ObservableCollection<ProductImage> processedImages);
    }
}