using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchwabenCode.QuickIO;

namespace DataAccess.Contract.Interfaces
{
    public interface IDataAccessRepository
    {
        void SetSourceDirectory(string path);
        void SetDestinationDirectory(string path);
        Task CopyFile(string filename);
        Task FindAllFiles();
        Task<IReadOnlyCollection<QuickIOFileInfo>> FindFile(string filename);
    }
}
