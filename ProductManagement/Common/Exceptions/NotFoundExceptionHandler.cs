using Microsoft.AspNetCore.Diagnostics;

namespace ProductManagement.Common.Exceptions;

public class NotFoundExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not KeyNotFoundException)
            return false;

        httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

        await httpContext.Response.WriteAsJsonAsync(
            new
            {
                status= StatusCodes.Status404NotFound,
                title = "Resource not found",
                detail = exception.Message
            },
            cancellationToken);

        return true;
    }
}
