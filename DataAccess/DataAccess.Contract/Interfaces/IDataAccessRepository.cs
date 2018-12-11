using SchwabenCode.QuickIO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Contract.Interfaces
{
    public interface IDataAccessRepository
    {
        void SetSourceDirectory(string path);
        Task SetDestinationDirectory(string path);
        string GetDestinationDirectoryPath();
        Task<string> CopyFile(string filename);
        int FindAllFiles();
        Task<IReadOnlyCollection<QuickIOFileInfo>> FindFile(string filename, bool startsWith);
        bool IsSourceDirectorySet();
        bool IsDestinationDirectorySet();
        void DeleteFile(string id);
        Task<string> LoadFromDestinationDirectory();
        Task<IReadOnlyCollection<QuickIOFileInfo>> EnumerateDestinationDirectoryFiles();
        void SaveProcessedImagesList(string filesList);
    }
}
