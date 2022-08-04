using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patron.WebWriter.Data.Dto
{
    public class Attachment
    {
        public Stream Stream { get; set; }

        public string FileName { get; set; }
    }
}
