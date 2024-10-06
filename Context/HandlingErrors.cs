using System.Net;
using HttpExceptions.Exceptions;

namespace server.Context;

// ReSharper disable once NotAccessedPositionalProperty.Global
public record ExceptionResponse(HttpStatusCode StatusCode, string Description);

public class HandlingErrors(RequestDelegate next, ILogger<HandlingErrors> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        logger.LogError(exception, "An unexpected error occurred.");

        var response = exception switch
        {
            BadRequestException e => new ExceptionResponse(HttpStatusCode.BadRequest, e.Message),
            NotFoundException e => new ExceptionResponse(HttpStatusCode.NotFound, e.Message),
            UnauthorizedException e => new ExceptionResponse(HttpStatusCode.Unauthorized, e.Message),
            ForbiddenException e => new ExceptionResponse(HttpStatusCode.Forbidden, e.Message),
            _ => new ExceptionResponse(HttpStatusCode.InternalServerError, "Internal server error. Please retry later.")
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)response.StatusCode;
        await context.Response.WriteAsJsonAsync(response);
    }
}