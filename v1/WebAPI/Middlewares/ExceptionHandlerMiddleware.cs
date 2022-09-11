using CleanArchitecture.Api.Constants;
using CleanArchitecture.Api.Response;
using Newtonsoft.Json;
using System.Net;

namespace CleanArchitecture.Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string result = "";
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Unexpected caused by: {exception}");
                result = CreateErrorResponse(context, (int)HttpStatusCode.BadRequest, exception.Message);
            }
        }

        private string CreateErrorResponse(HttpContext context, int statusCode, string message)
        {
            var errorResponse =
                JsonConvert.SerializeObject(new ErrorResponse(statusCode, message));
            context.Response.ContentType = HeaderConstants.ResponseContentType;
            context.Response.StatusCode = statusCode;
            return errorResponse;
        }
    }
}
