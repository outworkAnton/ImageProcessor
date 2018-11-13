using SchwabenCode.QuickIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contract.Interfaces
{
    public interface IDataAccessRepository
    {
        void SetSourceDirectory(string path);
        Task SetDestinationDirectory(string path);
        Task CopyFile(string filename);
        Task<int> FindAllFiles();
        Task<IReadOnlyCollection<QuickIOFileInfo>> FindFile(string filename);
    }
}
