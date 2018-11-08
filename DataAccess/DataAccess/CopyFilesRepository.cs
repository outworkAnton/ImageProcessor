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
        private IEnumerable<QuickIOFileInfo> _filesFounded;
        private QuickIODirectoryInfo _sourceDirectory;
        private QuickIODirectoryInfo _destinationDirectory;

        public void SetSourceDirectory(string path)
        {
            _sourceDirectory = new QuickIODirectoryInfo(path);
        }

        public void SetDestinationDirectory(string path)
        {
            _destinationDirectory = new QuickIODirectoryInfo(path);
        }

        public async Task CopyFile(string filename)
        {
            try
            {
                var item = _filesFounded.FirstOrDefault(f => f.Name == filename);
                await QuickIOFile.CopyToDirectoryAsync(item, _destinationDirectory).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new IOException(ex.Message);
            }
        }

        public async Task FindAllFiles()
        {
            try
            {
                _filesFounded = await _sourceDirectory.EnumerateFilesAsync("*.jpg", SearchOption.AllDirectories).ConfigureAwait(false);
            }
            catch (Exception exc)
            {
                throw new IOException(exc.Message);
            }
        }

        public async Task<IReadOnlyCollection<QuickIOFileInfo>> FindFile(string filename)
        {
            if (!_filesFounded.Any())
            {
                await FindAllFiles().ConfigureAwait(false);
            }
            return _filesFounded.Where(f => f.Name.StartsWith(filename)).ToArray();
        }
    }
}
