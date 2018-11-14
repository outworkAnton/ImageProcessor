using System;
using System.Collections.Generic;
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
            return await _repository.FindAllFiles().ConfigureAwait(false);
        }

        public void SetSourceDirectory(string path)
        {
            _repository.SetSourceDirectory(path);
        }

        public async Task SetDestinationDirectory(string path)
        {
            await _repository.SetDestinationDirectory(path).ConfigureAwait(false);
        }

        public async Task<IReadOnlyCollection<ProductImage>> FindFiles(string filename)
        {
            return (await _repository.FindFile(filename).ConfigureAwait(false))
                .Select(FileToModelConverter.ConvertToModel)
                .ToArray();
        }

        public async Task<string> CopyFile(string id)
        {
            return await _repository.CopyFile(id).ConfigureAwait(false);
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