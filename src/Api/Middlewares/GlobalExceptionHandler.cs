using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext context,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var problem = new ProblemDetails
        {
            Title = "Erro Interno no Servidor",
            Status = (int)HttpStatusCode.InternalServerError,
            Detail = exception.Message,
            Type = exception.GetType().Name,
            Instance = context.Request.Path
        };

        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        await context.Response.WriteAsJsonAsync(problem, cancellationToken);

        return true;
    }
}