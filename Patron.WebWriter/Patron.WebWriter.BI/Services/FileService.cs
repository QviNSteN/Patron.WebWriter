using Patron.WebWriter.BI.Interfaces;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patron.WebWriter.BI.Options;
using Patron.WebWriter.General.Expansions;
using Patron.WebWriter.Data.Dto;

namespace Patron.WebWriter.BI.Services
{
    /// <summary>
    /// Сервис по работе с файлами
    /// </summary>
    public class FileService : IFile
    {
        private readonly BackendFilesOptions _options;

        public FileService(BackendFilesOptions options)
        {
            _options = options;
        }

        public async Task<byte[]> ReadByteFileByFilename(string fileName)
        {
            var path = GetPath(fileName);

            if (!File.Exists(path))
                throw new NullReferenceException($"Файл с именем {fileName} по пути {path} не найден!");

            return await File.ReadAllBytesAsync(GetPath(fileName));
        }

        public async Task<string> ReadFileByFilename(string fileName)
        {
            var path = GetPath(fileName);

            if (!File.Exists(path))
                throw new NullReferenceException($"Файл с именем {fileName} по пути {path} не найден!");

            return await File.ReadAllTextAsync(GetPath(fileName));
        }

        public async Task<Stream> ReadStreamFileByFilename(string fileName)
        {
            var path = GetPath(fileName);

            if (!File.Exists(path))
                throw new NullReferenceException($"Файл с именем {fileName} по пути {path} не найден!");

            MemoryStream ms = new MemoryStream();

            using (FileStream fs = File.Open(GetPath(fileName), FileMode.Open))
            {
                await fs.CopyToAsync(ms);
            }

            return ms;
        }

        public async Task<Attachment> ReadStreamFileByFilenameInAttachment(string fileName) =>
            new Attachment()
            {
                FileName = fileName,
                Stream = await ReadStreamFileByFilename(fileName)
            };

        public Task<string> ReadTextFileByFilename(string fileName)
        {
            throw new NotImplementedException();
        }

        private string GetPath(string filename) => $"{_options.MainPath.FixPath()}{filename}";
    }
}
