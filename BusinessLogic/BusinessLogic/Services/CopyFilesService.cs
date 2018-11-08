using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Contract.Interfaces;
using BusinessLogic.Models;
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

        public void SetSourceDirectory(string path)
        {
            _repository.SetSourceDirectory(path);
        }

        public void SetDestinationDirectory(string path)
        {
            _repository.SetDestinationDirectory(path);
        }

        public async Task<IReadOnlyCollection<ProductImage>> FindFiles(string filename)
        {
            return (await _repository.FindFile(filename).ConfigureAwait(false))
                .Select(FileToModelConverter.ConvertToModel)
                .ToArray();
        }

        public async Task CopyFile(string id)
        {
            await _repository.CopyFile(id).ConfigureAwait(false);
        }
    }
}