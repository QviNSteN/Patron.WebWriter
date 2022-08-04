using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Patron.WebWriter.BI.Interfaces;
using Patron.WebWriter.Data.Return;
using Patron.WebWriter.EF;
using Patron.WebWriter.Data.Filters;
using Patron.WebWriter.General.Expansions;
using Patron.WebWriter.Data.Enums;
using Patron.WebWriter.Data.Entity;
using Microsoft.Extensions.Logging;
using Patron.WebWriter.Data.Dto;

namespace Patron.WebWriter.BI.Services
{
    /// <summary>
    /// Сервис отвечающий за обработку запросов предоставляемых бэкенду.
    /// </summary>
    public class Backend : IBackend
    {
        /// <summary>
        /// Хранилище одновременно существующих обработок файлов
        /// </summary>
        private ConcurrentDictionary<string, Task<Attachment>> BackendHandling = new ConcurrentDictionary<string, Task<Attachment>>();
        private readonly object lockObject = new object();

        private readonly IFile _file;

        public Backend(IFile file)
        {
            _file = file;
        }

        public async Task<BackendReturn> HandlingFile(string fileName)
        {
            if (!IsCorrectNaming(fileName))
                return BadRequest("В поступившем имени файла содержатся запрещённые символы!");

            try
            {
                return Ok(await GetStreamFileOrCashAwait(fileName));
            }
            catch(NullReferenceException)
            {
                return NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            finally
            {
                BackendHandling.TryRemove(fileName, out _);
            }
        }

        private Task<Attachment> GetStreamFileOrCashAwait(string filename)
        {
            lock (lockObject)
            {
                return BackendHandling.GetOrAdd(filename, fileName => Task.Run(async () => {
                    var result = await _file.ReadStreamFileByFilenameInAttachment(filename);

                    await Task.Delay(2000);
                    return result;
                }));
            }
        }

        private bool IsCorrectNaming(string fileName) => !fileName.Intersect(Path.GetInvalidFileNameChars()).Any();

        private BackendReturn BadRequest(Exception ex)
        {
            //_logger.LogError(1, exception: ex, ex.Message);
            return BadRequest(ex.Message);
        }

        private BackendReturn BadRequest(string errorMessage) => new BackendReturn(errorMessage)
        {
            Code = CodeRequest.BadRequest
        };

        private BackendReturn NotFound(string errorMessage) => new BackendReturn(errorMessage)
        {
            Code = CodeRequest.NotFound
        };

        private BackendReturn NotFound() => NotFound("Файл с указанным именем не найден!");

        private BackendReturn Ok(Stream file, string fileName) => new BackendReturn(new Attachment() { Stream = file, FileName = fileName })
        {
            Code = CodeRequest.Ok
        };

        private BackendReturn Ok(Attachment attachment) => new BackendReturn(attachment)
        {
            Code = CodeRequest.Ok
        };
    }
}
