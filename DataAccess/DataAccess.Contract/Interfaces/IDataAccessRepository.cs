using System.Collections.Generic;
using System.IO;

namespace DataAccess.Contract.Interfaces
{
    public interface IDataAccessRepository
    {
        void SetSourceDirectory(string path);
        void SetDestinationDirectory(string path);
        string GetDestinationDirectoryPath();
        string CopyFile(string filename);
        int FindAllFiles();
        IReadOnlyCollection<FileInfo> FindFile(string filename, bool startsWith);
        bool IsSourceDirectorySet();
        bool IsDestinationDirectorySet();
        void DeleteFile(string id);
        string LoadFromDestinationDirectory();
        IReadOnlyCollection<FileInfo> EnumerateDestinationDirectoryFiles();
        void SaveProcessedImagesList(string filesList);
    }
}
