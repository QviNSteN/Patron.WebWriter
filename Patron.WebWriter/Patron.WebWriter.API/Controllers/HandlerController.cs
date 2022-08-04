using AutoMapper;
using AutoMapper.Collection;
using AutoMapper.EntityFrameworkCore;
using Patron.WebWriter.API.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Patron.WebWriter.Data.Dto;
using Patron.WebWriter.BI.Interfaces;

namespace Patron.WebWriter.API.Controllers
{
    [ApiController]
    [Route("")]
    public class HandlerController : BaseController
    {
        private readonly ILogger<HandlerController> _logger;
        private readonly IMapper _mapper;
        private readonly IBackend _backend;

        public HandlerController(ILogger<HandlerController> logger, IMapper mapper, IBackend backend)
        {
            _logger = logger;
            _mapper = mapper;
            _backend = backend;
        }

        /// <summary>
        /// Основной роут всего бэкенда приложения. Запросы необходимо посылать на доступ информации файлам
        /// </summary>
        /// <param name="model">Содержит внутри себя информацию о запрашиваемом файле backend'а</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> BackendRequest([FromQuery] HandlerInput model)
        {
            var result = await _backend.HandlingFile(model.Filename);

            return File(result);
        }
    }
}
