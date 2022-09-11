using LMS.Core.Tools.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesErrorResponseType(typeof(ErrorResponse))]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender _mediator = null!;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        public override OkObjectResult Ok(object? data)
        {
            return base.Ok(new SuccessResponse(200, "", data));
        }

        [NonAction]
        public OkObjectResult Ok(object? data, string message)
        {
            return base.Ok(new SuccessResponse(200, message, data));
        }
    }
}
