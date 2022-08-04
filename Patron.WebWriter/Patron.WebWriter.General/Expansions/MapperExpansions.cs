using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Patron.WebWriter.General.Expansions
{
    public static class MapperExpansions
    {
        public static T ToDto<T>(this object entity, IMapper mapper)
        {
            return mapper.Map<T>(entity);
        }
    }
}
