using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using BusinessLogic.Contract.Interfaces;
using BusinessLogic.Contract.Models;
using DataAccess.Contract.Interfaces;
using Newtonsoft.Json;

namespace BusinessLogic.Services
{
    public class CopyFilesService : ICopyFilesService
    {
        private readonly IDataAccessRepository _copyFilesRepository;

        public CopyFilesService(IDataAccessRepository copyFilesRepository) => _copyFilesRepository = copyFilesRepository 
            ?? throw new ArgumentNullException(nameof(copyFilesRepository));

        public int FindAllFiles()
        {
            try
            {
                return _copyFilesRepository.FindAllFiles();
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

        public void SetDestinationDirectory(string path)
        {
            try
            {
                _copyFilesRepository.SetDestinationDirectory(path);
            }
            catch (Exception ex)
            {
                throw new DirectoryNotFoundException(ex.Message);
            }
        }

        public IReadOnlyCollection<ProductImage> FindFiles(string filename, bool startsWith)
        {
            try
            {
                return _copyFilesRepository
                    .FindFile(filename, startsWith)?
                    .Select(FileToModelConverter.ConvertToModel)?
                    .ToArray();
            }
            catch (Exception ex)
            {
                throw new FileNotFoundException(ex.Message);
            }
        }

        public string CopyFile(string filename)
        {
            try
            {
                return _copyFilesRepository.CopyFile(filename);
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

        public void DeleteFile(string id)
        {
            try
            {
                _copyFilesRepository.DeleteFile(id);
            }
            catch (IOException io)
            {
                throw new IOException(io.Message);
            }
        }

        public ObservableCollection<ProductImage> LoadFromDestinationDirectory()
        {
            try
            {
                var files = new ObservableCollection<ProductImage>();
                var bclFile = _copyFilesRepository
                            .LoadFromDestinationDirectory();
                if (!string.IsNullOrWhiteSpace(bclFile))
                {
                    files = JsonConvert
                        .DeserializeObject<ObservableCollection<ProductImage>>(bclFile);
                }
                else
                {
                    var filesInDir = _copyFilesRepository.EnumerateDestinationDirectoryFiles();

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
            catch (IOException)
            {
                return new ObservableCollection<ProductImage>();
            }
        }

        public void SaveProcessedImagesList(ObservableCollection<ProductImage> processedImages)
        {
            try
            {
                var filesList = JsonConvert.SerializeObject(processedImages, Formatting.None);
                _copyFilesRepository.SaveProcessedImagesList(filesList);
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