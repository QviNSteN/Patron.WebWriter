using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patron.WebWriter.Data.Enums;

namespace Patron.WebWriter.Data.Return
{
    public class BaseReturn<T>
    {
        public BaseReturn() { }

        public bool Success => Code switch
        {
            CodeRequest.Ok => true,
            _ => false
        };

        public CodeRequest Code { get; set; }

        public string Message { get; set; }

        public T Model { get; set; }
    }
}
