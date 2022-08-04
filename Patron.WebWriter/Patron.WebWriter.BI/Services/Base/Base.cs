using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patron.WebWriter.Data.Return;
using Patron.WebWriter.Data.Enums;
using Patron.WebWriter.EF;
using AutoMapper;

namespace Patron.WebWriter.BI.Services
{
    public class Base<TEntity, Tdto>
    {
        internal readonly ServiceDbContext _context;
        internal readonly IMapper _mapper;
        public Base (IMapper mapper, ServiceDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public virtual T Ok<T, TReturn>() where T : BaseReturn<TReturn>, new()
        {
            return new T() { Code = CodeRequest.Ok };
        }

        public virtual BaseReturn<T> Ok<T>(BaseReturn<T> okModel)
        {
            okModel.Code = CodeRequest.Ok;

            return okModel;
        }

        public virtual T Ok<T, TReturn>(T okModel) where T : BaseReturn<TReturn>
        {
            okModel.Code = CodeRequest.Ok;

            return okModel;
        }

        public virtual T Error<T, TReturn>(string message, CodeRequest code = CodeRequest.BadRequest) where T : BaseReturn<TReturn>, new()
        {
            return new T() { Message = message, Code = code };
        }

        public TEntity GetEntities<T>(T dto)
        {
            return _mapper.Map<T, TEntity>(dto);
        }

        public TEntity GetEntity<T>(T dto)
        {
            return _mapper.Map<TEntity>(dto);
        }
    }
}
