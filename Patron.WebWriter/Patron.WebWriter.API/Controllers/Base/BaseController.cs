using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Patron.WebWriter.Data.Return;
using Patron.WebWriter.Data.Enums;
using System.IO;
using Patron.WebWriter.Data.Dto;

namespace Patron.WebWriter.API.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        internal new OkObjectResult Ok() => base.Ok(new
        {
            Done = true
        });


        internal new BadRequestObjectResult BadRequest() => base.BadRequest(new
        {
            Done = false
        });

        internal BadRequestObjectResult BadRequest(string errorMessage) => base.BadRequest(new
        {
            Done = false,
            Message = errorMessage
        });

        internal NotFoundObjectResult NotFound(string errorMessage) => base.NotFound(new
        {
            Done = false,
            Message = errorMessage
        });

        internal IActionResult Result<T>(BaseReturn<T> model)
        {
            if (!model.Success)
                return GetError(model.Code, model.Message);

            return Ok(model.Model);
        }

        internal IActionResult File<T>(BaseReturn<T> attachment)
        {
            if (!attachment.Success)
                return GetError(attachment.Code, attachment.Message);

            var model = attachment.Model as Attachment;

            return base.File((model.Stream as MemoryStream).ToArray(), "application/octet-stream", model.FileName);
        }

        private IActionResult GetError(CodeRequest code, string errorMessage) =>
            code switch
            {
                CodeRequest.NotFound => NotFound(errorMessage),
                CodeRequest.BadRequest => BadRequest(errorMessage),
                _ => BadRequest("Непредвиденная ошимбка!")
            };
    }
}
