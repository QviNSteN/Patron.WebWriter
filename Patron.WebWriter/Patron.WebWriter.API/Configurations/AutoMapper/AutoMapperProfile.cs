using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Patron.WebWriter.Data;
using Patron.WebWriter.Data.Entity;
using System;
using System.IO;
using System.Linq;
using Patron.WebWriter.Data.Enums;
using Patron.WebWriter.General.Expansions;

namespace Patron.WebWriter.API.Configurations.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
        //    CreateMap<AttachmentDto, Attachment>()
        //        .ReverseMap();
        }
    }
}
