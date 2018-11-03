using SchwabenCode.QuickIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkCopier.Helpers
{
    public class FileSearchHelper
    {
        private IEnumerable<QuickIOFileInfo> _filesFounded;

        public async Task<IReadOnlyCollection<QuickIOFileInfo>> GetFiles(string directory)
        {
            try
            {
                var dir = new QuickIODirectoryInfo(directory);
                _filesFounded = await dir.EnumerateFilesAsync("*.jpg", SearchOption.AllDirectories).ConfigureAwait(false);
                return _filesFounded.ToArray();
            }
            catch (Exception exc)
            {
                throw new IOException(exc.Message);
            }
        }

        public IReadOnlyCollection<QuickIOFileInfo> GetFile(string filename)
        {
            return _filesFounded.Where(f => f.Name.StartsWith(filename)).ToArray();
        }
    }
}
