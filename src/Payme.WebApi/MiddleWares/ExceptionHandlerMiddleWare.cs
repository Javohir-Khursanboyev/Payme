using Payme.Service.Exceptions;
using Payme.WebApi.Models;
using System.Net;

namespace Payme.WebApi.MiddleWares;

public class ExceptionHandlerMiddleWare
{
    private readonly RequestDelegate next;

    public ExceptionHandlerMiddleWare(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (CustomException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsJsonAsync(new Response()
            {
                Message = ex.Message,
                StatusCode = ex.StatusCode
            });
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(new Response()
            {
                Message = ex.Message,
                StatusCode = 500
            });
        }
    }
}