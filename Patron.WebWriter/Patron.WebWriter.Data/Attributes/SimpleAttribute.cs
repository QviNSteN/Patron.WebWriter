using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patron.WebWriter.Data.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class SimpleAttribute : Attribute
    {

        public SimpleAttribute()
        {

        }
    }
}
