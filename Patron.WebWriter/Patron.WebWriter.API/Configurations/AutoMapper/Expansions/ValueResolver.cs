using AutoMapper;
using Patron.WebWriter.BI.Options;
using Patron.WebWriter.General.Expansions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Patron.WebWriter.Data.Enums;
using Patron.WebWriter.Data.Entity;
using Patron.WebWriter.BI.Interfaces;
using Patron.WebWriter.Data.Generic;

namespace Patron.WebWriter.API.Configurations.AutoMapper
{
    public class FormatterObjectToString : IValueResolver<object, object, string>
    {
        private readonly IMapper _mapper;

        public FormatterObjectToString(IMapper mapper)
        {
            _mapper = mapper;
        }

        public string Resolve(object source, object destination, string result, ResolutionContext context)
        {
            return result;
        }
    }

}