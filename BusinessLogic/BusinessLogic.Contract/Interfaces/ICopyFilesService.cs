using BusinessLogic.Contract.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Contract.Interfaces
{
    public interface ICopyFilesService
    {
        Task<int> FindAllFiles();
        void SetSourceDirectory(string path);
        Task SetDestinationDirectory(string path);
        Task<IReadOnlyCollection<ProductImage>> FindFiles(string filename);
        Task<string> CopyFile(string id);
        bool IsSourceDirectorySet();
        bool IsDestinationDirectorySet();
    }
}