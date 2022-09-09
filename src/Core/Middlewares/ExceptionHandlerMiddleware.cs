
using LMS.Core.Exceptions;
using LMS.Core.Tools.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace LMS.Core.Middlewares;

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
        catch (ValidationException ex)
        {
            result = CreateErrorResponse(context, (int) HttpStatusCode.UnprocessableEntity, ex.Message, ex.Failures);
        }
        catch (Exception ex)
        {
            result = CreateErrorResponse(context, (int)HttpStatusCode.InternalServerError, "error.occured", ex.Message);
        }

        await context.Response.WriteAsync(result);
    }

    private string CreateErrorResponse(HttpContext context, int statusCode, string message, object? detail = null)
    {
        var errorResponse = JsonSerializer.Serialize(new ErrorResponse(statusCode, message, detail));
        context.Response.StatusCode = statusCode;
        return errorResponse;
    }
}
