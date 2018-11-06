﻿using DataAccess.Contract.Interfaces;
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
        private readonly QuickIODirectoryInfo _destinationDirectory;
        private readonly QuickIODirectoryInfo _sourceDirectory;

        public CopyFilesRepository(string sourceDirectory, string destinationDirectory)
        {
            _sourceDirectory = new QuickIODirectoryInfo(sourceDirectory);
            _destinationDirectory = new QuickIODirectoryInfo(destinationDirectory);
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

        public IReadOnlyCollection<QuickIOFileInfo> GetFile(string filename)
        {
            return _filesFounded.Where(f => f.Name.StartsWith(filename)).ToArray();
        }
    }
}
