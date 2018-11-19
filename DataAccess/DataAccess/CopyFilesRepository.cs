using DataAccess.Contract.Interfaces;
using SchwabenCode.QuickIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CopyFilesRepository : IDataAccessRepository
    {
        private List<QuickIOFileInfo> _filesFound = new List<QuickIOFileInfo>();
        private QuickIODirectoryInfo _sourceDirectory;
        private QuickIODirectoryInfo _destinationDirectory;

        public void SetSourceDirectory(string path)
        {
            try
            {
                if (path == null)
                {
                    _sourceDirectory = null;
                    return;
                }
                _sourceDirectory = new QuickIODirectoryInfo(path);
            }
            catch
            {
                throw new DirectoryNotFoundException("Папка с исходными изображениями не найдена");
            }
        }

        public async Task SetDestinationDirectory(string path)
        {
            try
            {
                if (path == null)
                {
                    _destinationDirectory = null;
                    return;
                }
                var destPath = path;
                if (!await QuickIODirectory.ExistsAsync(destPath).ConfigureAwait(false))
                {
                    var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    destPath = Path.Combine(desktopPath, path);
                    await QuickIODirectory.CreateAsync(destPath).ConfigureAwait(false);
                }
                _destinationDirectory = new QuickIODirectoryInfo(destPath);
            }
            catch
            {
                throw new DirectoryNotFoundException("Целевая папка не создана или не доступна");
            }
        }

        public async Task<string> CopyFile(string filename)
        {
            try
            {
                if (!await QuickIODirectory.ExistsAsync(_sourceDirectory).ConfigureAwait(false))
                {
                    throw new DirectoryNotFoundException("Папка с исходными изображениями не доступна");
                }

                if (!await QuickIODirectory.ExistsAsync(_destinationDirectory).ConfigureAwait(false))
                {
                    throw new DirectoryNotFoundException("Целевая папка не доступна");
                }

                var item = _filesFound.Find(f => f.Name == filename + ".jpg");
                var newFilePath = Path.Combine(_destinationDirectory.FullName, Path.GetFileName(item.FullName));
                if (await QuickIOFile.ExistsAsync(newFilePath).ConfigureAwait(false))
                {
                    throw new ArgumentException($"Файл {filename} уже существует");
                }

                await QuickIOFile.CopyToDirectoryAsync(item, _destinationDirectory).ConfigureAwait(false);

                if (await QuickIOFile.ExistsAsync(newFilePath).ConfigureAwait(false))
                {
                    return newFilePath;
                }

                throw new FileNotFoundException($"Файл {filename} не скопирован");
            }
            catch (ArgumentException fae)
            {
                throw new ArgumentException(fae.Message);
            }
            catch (FileNotFoundException fnf)
            {
                throw new FileNotFoundException(fnf.Message);
            }
            catch (DirectoryNotFoundException dnf)
            {
                throw new DirectoryNotFoundException(dnf.Message);
            }
        }

        public async Task<int> FindAllFiles()
        {
            _filesFound.Clear();
            try
            {
                _filesFound.AddRange((await _sourceDirectory
                    .EnumerateFilesAsync("*.jpg", SearchOption.AllDirectories, QuickIOEnumerateOptions.SuppressAllExceptions)
                    .ConfigureAwait(false)).ToArray());

            }
            catch
            {
                try
                {
                    var files = FindAccessableFiles(_sourceDirectory.FullName, "*.jpg", true)
                .Select(file => new QuickIOFileInfo(file)).ToList();
                    _filesFound.AddRange(files);
                }
                catch
                {
                    throw new IOException("Возникла ошибка при попытке получить список файлов из исходной папки");
                }
            }
            return _filesFound.Count;
        }

        private IEnumerable<string> FindAccessableFiles(string path, string file_pattern, bool recurse)
        {
            Console.WriteLine(path);
            var required_extension = "jpg";

            if (File.Exists(path))
            {
                yield return path;
                yield break;
            }

            if (!Directory.Exists(path))
            {
                yield break;
            }

            if (null == file_pattern)
                file_pattern = "*." + required_extension;

            var top_directory = new DirectoryInfo(path);

            IEnumerator<FileInfo> files;
            try
            {
                files = top_directory.EnumerateFiles(file_pattern).GetEnumerator();
            }
            catch (Exception)
            {
                files = null;
            }

            while (true)
            {
                FileInfo file = null;
                try
                {
                    if (files?.MoveNext() == true)
                        file = files.Current;
                    else
                        break;
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
                catch (PathTooLongException)
                {
                    continue;
                }

                yield return file.FullName;
            }

            if (!recurse)
                yield break;

            IEnumerator<DirectoryInfo> dirs;
            try
            {
                dirs = top_directory.EnumerateDirectories("*").GetEnumerator();
            }
            catch (Exception)
            {
                dirs = null;
            }


            while (true)
            {
                DirectoryInfo dir = null;
                try
                {
                    if (dirs?.MoveNext() == true)
                        dir = dirs.Current;
                    else
                        break;
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
                catch (PathTooLongException)
                {
                    continue;
                }

                foreach (var subpath in FindAccessableFiles(dir.FullName, file_pattern, recurse))
                    yield return subpath;
            }
        }

        public async Task<IReadOnlyCollection<QuickIOFileInfo>> FindFile(string filename)
        {
            try
            {
                if (_filesFound.Count == 0)
                {
                    await FindAllFiles().ConfigureAwait(false);
                }
                if (!await _sourceDirectory.SafeExistsAsync().ConfigureAwait(false))
                {
                    return null;
                }
                return _filesFound.Where(f => f.Name.StartsWith(filename, StringComparison.OrdinalIgnoreCase)).ToArray();
            }
            catch
            {
                throw new FileNotFoundException("Возникла ошибка при поиске файла");
            }
        }

        public bool IsSourceDirectorySet() => _sourceDirectory != null;

        public bool IsDestinationDirectorySet() => _destinationDirectory != null;

        public async Task DeleteFile(string id)
        {
            var item = _filesFound.FirstOrDefault(f => f.Name == id + ".jpg");
            var fileForDelete = Path.Combine(_destinationDirectory.FullName, Path.GetFileName(item.FullName));
            await QuickIOFile.DeleteAsync(fileForDelete).ConfigureAwait(false);
        }
    }
}
