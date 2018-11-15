using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Contract.Interfaces;
using BusinessLogic.Contract.Models;
using DataAccess.Contract.Interfaces;

namespace BusinessLogic.Services
{
    public class CopyFilesService : ICopyFilesService
    {
        private readonly IDataAccessRepository _repository;

        public CopyFilesService(IDataAccessRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<int> FindAllFiles()
        {
            try
            {
                return await _repository.FindAllFiles().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new IOException(ex.Message);
            }
        }

        public void SetSourceDirectory(string path)
        {
            try
            {
                _repository.SetSourceDirectory(path);
            }
            catch (Exception ex)
            {
                throw new DirectoryNotFoundException(ex.Message);
            }
        }

        public async Task SetDestinationDirectory(string path)
        {
            try
            {
                await _repository.SetDestinationDirectory(path).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new DirectoryNotFoundException(ex.Message);
            }
        }

        public async Task<IReadOnlyCollection<ProductImage>> FindFiles(string filename)
        {
            try
            {
                return (await _repository.FindFile(filename).ConfigureAwait(false))?
                    .Select(FileToModelConverter.ConvertToModel)?
                    .ToArray();
            }
            catch (Exception ex)
            {
                throw new FileNotFoundException(ex.Message);
            }
        }

        public async Task<string> CopyFile(string id)
        {
            try
            {
                return await _repository.CopyFile(id).ConfigureAwait(false);
            }
            catch (FileNotFoundException fnf)
            {
                throw new FileNotFoundException(fnf.Message);
            }
            catch (DirectoryNotFoundException dnf)
            {
                throw new DirectoryNotFoundException(dnf.Message);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new IOException(ex.Message);
            }
        }

        public bool IsSourceDirectorySet()
        {
            return _repository.IsSourceDirectorySet();
        }

        public bool IsDestinationDirectorySet()
        {
            return _repository.IsDestinationDirectorySet();
        }
    }
}