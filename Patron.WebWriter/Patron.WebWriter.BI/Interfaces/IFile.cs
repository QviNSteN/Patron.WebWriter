using Patron.WebWriter.Data.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patron.WebWriter.BI.Interfaces
{
    /// <summary>
    /// Интерфейс по работе с файлами
    /// </summary>
    public interface IFile
    {
        /// <summary>
        /// Получить файл по имени, если существует. 
        /// </summary>
        /// <param name="fileName"></param>
        /// <exception cref="NullReferenceException">Вернётся, если не существует файла с указанным именем по пути из настроек</exception>
        /// <returns>Читает текст файла и передаёт в виде sting</returns>
        Task<string> ReadTextFileByFilename(string fileName);

        /// <summary>
        /// Получить файл по имени, если существует. 
        /// </summary>
        /// <param name="fileName"></param>
        /// <exception cref="NullReferenceException">Вернётся, если не существует файла с указанным именем по пути из настроек</exception>
        /// <returns>Читает файл как массив байт и передает в формате byte[]</returns>
        Task<byte[]> ReadByteFileByFilename(string fileName);

        /// <summary>
        /// Получить файл по имени, если существует. 
        /// </summary>
        /// <param name="fileName"></param>
        /// <exception cref="NullReferenceException">Вернётся, если не существует файла с указанным именем по пути из настроек</exception>
        /// <returns>Передаёт файл как поток байт в формате Stream</returns>
        Task<Stream> ReadStreamFileByFilename(string fileName);

        /// <summary>
        /// Получить файл по имени, если существует. 
        /// </summary>
        /// <param name="fileName"></param>
        /// <exception cref="NullReferenceException">Вернётся, если не существует файла с указанным именем по пути из настроек</exception>
        /// <returns>Передаёт файл как поток байт и конвертируется в модель Attachment</returns>
        Task<Attachment> ReadStreamFileByFilenameInAttachment(string fileName);
    }
}
