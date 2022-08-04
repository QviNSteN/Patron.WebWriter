using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patron.WebWriter.Data.Dto;

namespace Patron.WebWriter.Data.Return
{
    public class BackendReturn : BaseReturn<Attachment>
    {
        public BackendReturn() { }

        public BackendReturn(string message)
        {
            Message = message;
        }

        public BackendReturn(Attachment model)
        {
            Model = model;
        }
    }
}
