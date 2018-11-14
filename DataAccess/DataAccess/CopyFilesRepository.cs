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
            _sourceDirectory = new QuickIODirectoryInfo(path);
        }

        public async Task SetDestinationDirectory(string path)
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

        public async Task<string> CopyFile(string filename)
        {
            try
            {
                var item = _filesFound.FirstOrDefault(f => f.Name == filename + ".jpg");
                await QuickIOFile.CopyToDirectoryAsync(item, _destinationDirectory).ConfigureAwait(false);
                var newFilePath = Path.Combine(_destinationDirectory.FullName, Path.GetFileName(item.FullName));
                if (await QuickIOFile.ExistsAsync(newFilePath).ConfigureAwait(false))
                {
                    return newFilePath;
                }

                throw new IOException($"File {filename} not copied");
            }
            catch (Exception ex)
            {
                throw new IOException(ex.Message);
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
                var files = FindAccessableFiles(_sourceDirectory.FullName, "*.jpg", true)
                    .Select(file => new QuickIOFileInfo(file)).ToList();
                _filesFound.AddRange(files);
            }
            return _filesFound.Count();
        }

        private IEnumerable<string> FindAccessableFiles(string path, string file_pattern, bool recurse)
        {
            Console.WriteLine(path);
            var list = new List<string>();
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
            catch (Exception ex)
            {
                files = null;
            }

            while (true)
            {
                FileInfo file = null;
                try
                {
                    if (files != null && files.MoveNext())
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
            catch (Exception ex)
            {
                dirs = null;
            }


            while (true)
            {
                DirectoryInfo dir = null;
                try
                {
                    if (dirs != null && dirs.MoveNext())
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
            if (!_filesFound.Any())
            {
                await FindAllFiles().ConfigureAwait(false);
            }
            return _filesFound.Where(f => f.Name.StartsWith(filename, StringComparison.OrdinalIgnoreCase)).ToArray();
        }

        public bool IsSourceDirectorySet() => _sourceDirectory != null;

        public bool IsDestinationDirectorySet() => _destinationDirectory != null;
    }
}
