using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Contract.Interfaces;
using BusinessLogic.Contract.Models;
using DataAccess.Contract.Interfaces;
using Newtonsoft.Json;

namespace BusinessLogic.Services
{
    public class CopyFilesService : ICopyFilesService
    {
        private readonly IDataAccessRepository _copyFilesRepository;

        public CopyFilesService(IDataAccessRepository copyFilesRepository)
        {
            _copyFilesRepository = copyFilesRepository ?? throw new ArgumentNullException(nameof(copyFilesRepository));
        }

        public async Task<int> FindAllFiles()
        {
            try
            {
                return await _copyFilesRepository.FindAllFiles().ConfigureAwait(false);
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
                _copyFilesRepository.SetSourceDirectory(path);
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
                await _copyFilesRepository.SetDestinationDirectory(path).ConfigureAwait(false);
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
                return (await _copyFilesRepository.FindFile(filename).ConfigureAwait(false))?
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
                return await _copyFilesRepository.CopyFile(id).ConfigureAwait(false);
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
            return _copyFilesRepository.IsSourceDirectorySet();
        }

        public bool IsDestinationDirectorySet()
        {
            return _copyFilesRepository.IsDestinationDirectorySet();
        }

        public async Task DeleteFile(string id)
        {
            try
            {
                await _copyFilesRepository.DeleteFile(id).ConfigureAwait(false);
            }
            catch (IOException io)
            {
                throw new IOException(io.Message);
            }
        }

        public async Task<ObservableCollection<ProductImage>> LoadFromDestinationDirectory()
        {
            try
            {
                var files = new ObservableCollection<ProductImage>();
                var bclFile = await _copyFilesRepository
                            .LoadFromDestinationDirectory()
                            .ConfigureAwait(false);
                if (!string.IsNullOrWhiteSpace(bclFile))
                {
                    files = JsonConvert
                        .DeserializeObject<ObservableCollection<ProductImage>>(bclFile);
                }
                else
                {
                    var filesInDir = await _copyFilesRepository.EnumerateDestinationDirectoryFiles().ConfigureAwait(false);

                    if (filesInDir != null)
                    {
                        files = new ObservableCollection<ProductImage>(filesInDir
                            .Select(FileToModelConverter.ConvertToModel)
                            .ToArray());
                    }
                }

                return files;
            }
            catch (FileLoadException fl)
            {
                throw new FileLoadException(fl.Message);
            }
            catch (IOException io)
            {
                throw new IOException(io.Message);
            }
        }

        public async Task SaveProcessedImagesList(ObservableCollection<ProductImage> processedImages)
        {
            try
            {
                var filesList = JsonConvert.SerializeObject(processedImages, Formatting.None);
                await _copyFilesRepository.SaveProcessedImagesList(filesList).ConfigureAwait(false);
            }
            catch (IOException io)
            {
                throw new IOException(io.Message);
            }
        }

        public string GetDestinationDirectoryPath()
        {
            return _copyFilesRepository.GetDestinationDirectoryPath();
        }
    }
}