using BusinessLogic.Contract.Interfaces;
using DataAccess.Contract.Interfaces;

namespace BusinessLogic.Services
{
    public class CopyFilesService : ICopyFilesService
    {
        private readonly IDataAccessRepository _repository;

        public CopyFilesService(IDataAccessRepository repository)
        {
            _repository = repository;
        }
    }
}