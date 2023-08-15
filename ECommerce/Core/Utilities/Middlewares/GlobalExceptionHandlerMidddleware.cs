using Core.Entities.Concrete;
using Core.Utilities.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Core.Utilities.Middlewares;

public class GlobalExceptionHandlerMidddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionHandlerMidddleware(RequestDelegate next)
    {
        _next = next;
    }


    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException ex)
        {
         await   HandlingNptFoundException(context, ex);
        }
        catch (Exception ex)
        {
            await HandlingException(context, ex);
        }
    }

    private async Task HandlingException(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        string message = "Internal server error";
     
        if (exception is ArgumentNullException)
        {
            message = "Argument is null";
        }

        await context.Response.WriteAsync(
            new ErrorDetail
            {
                Message = message,
                StatusCode = context.Response.StatusCode
            }.ToString()
            );

    }
    private async Task HandlingNptFoundException(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
        string message = "Object is not found";       
        await context.Response.WriteAsync(
            new ErrorDetail
            {
                Message = message,
                StatusCode = context.Response.StatusCode
            }.ToString()
            );

    }

}
