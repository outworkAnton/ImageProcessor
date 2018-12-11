using BusinessLogic.Contract.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BusinessLogic.Contract.Interfaces
{
    public interface ICopyFilesService
    {
        int FindAllFiles();
        void SetSourceDirectory(string path);
        void SetDestinationDirectory(string path);
        string GetDestinationDirectoryPath();
        IReadOnlyCollection<ProductImage> FindFiles(string filename, bool startsWith);
        string CopyFile(string filename);
        bool IsSourceDirectorySet();
        bool IsDestinationDirectorySet();
        void DeleteFile(string id);
        ObservableCollection<ProductImage> LoadFromDestinationDirectory();
        void SaveProcessedImagesList(ObservableCollection<ProductImage> processedImages);
    }
}