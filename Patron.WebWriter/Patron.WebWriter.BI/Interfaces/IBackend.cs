using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patron.WebWriter.Data.Entity;
using Patron.WebWriter.Data.Return;

namespace Patron.WebWriter.BI.Interfaces
{
    /// <summary>
    /// Интерфейс отвечающий за обработку запросов предоставляемых бэкенду.
    /// </summary>
    public interface IBackend
    {
        /// <summary>
        /// Обрабатывает содердимое запрошенного файла и возвращает результат.
        /// </summary>
        /// <param name="fileName">Название запрашиваемого файла</param>
        /// <returns>Файл содержит код состояния, а так же, либо модель результата, либо сообщение об ошибке.</returns>
        Task<BackendReturn> HandlingFile(string fileName);
    }
}
