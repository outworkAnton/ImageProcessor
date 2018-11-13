using DataAccess.Contract.Interfaces;
using SchwabenCode.QuickIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CopyFilesRepository : IDataAccessRepository
    {
        private IReadOnlyCollection<QuickIOFileInfo> _filesFound;
        private QuickIODirectoryInfo _sourceDirectory;
        private QuickIODirectoryInfo _destinationDirectory;

        public void SetSourceDirectory(string path)
        {
            _sourceDirectory = new QuickIODirectoryInfo(path);
        }

        public async Task SetDestinationDirectory(string path)
        {
            var destPath = path;
            if (!await QuickIODirectory.ExistsAsync(destPath).ConfigureAwait(false))
            {
                var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                destPath = Path.Combine(desktopPath, path);
                await QuickIODirectory.CreateAsync(destPath).ConfigureAwait(false);
            }
            _destinationDirectory = new QuickIODirectoryInfo(destPath);
        }

        public async Task CopyFile(string filename)
        {
            try
            {
                var item = _filesFound.FirstOrDefault(f => f.Name == filename);
                await QuickIOFile.CopyToDirectoryAsync(item, _destinationDirectory).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new IOException(ex.Message);
            }
        }

        public async Task<int> FindAllFiles()
        {
            try
            {
                _filesFound = (await _sourceDirectory
                    .EnumerateFilesAsync("*.jpg", SearchOption.AllDirectories)
                    .ConfigureAwait(false)).ToArray();
            }
            catch
            {
                var dirExc = new DirectoryInfo(_sourceDirectory.FullName);
                var files = dirExc.GetFiles("*.jpg", SearchOption.AllDirectories);
                _filesFound = files.Select(f => new QuickIOFileInfo(f.FullName)).ToArray();
            }
            return _filesFound.Count();
        }

        public async Task<IReadOnlyCollection<QuickIOFileInfo>> FindFile(string filename)
        {
            if (!_filesFound.Any())
            {
                await FindAllFiles().ConfigureAwait(false);
            }
            return _filesFound.Where(f => f.Name.StartsWith(filename)).ToArray();
        }
    }
}
