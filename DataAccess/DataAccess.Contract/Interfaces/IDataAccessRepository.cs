using SchwabenCode.QuickIO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Contract.Interfaces
{
    public interface IDataAccessRepository
    {
        void SetSourceDirectory(string path);
        Task SetDestinationDirectory(string path);
        Task<string> CopyFile(string filename);
        Task<int> FindAllFiles();
        Task<IReadOnlyCollection<QuickIOFileInfo>> FindFile(string filename);
        bool IsSourceDirectorySet();
        bool IsDestinationDirectorySet();
    }
}
