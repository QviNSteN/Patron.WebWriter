using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Patron.WebWriter.Data.Dto
{
    /// <summary>
    /// Входные параметры для получения данных от обработчика
    /// </summary>
    public class HandlerInput
    {
        /// <summary>
        /// Название файла запрашиваемого у обработчика
        /// </summary>
        [Required]
        public string Filename { get; set; }
    }
}
