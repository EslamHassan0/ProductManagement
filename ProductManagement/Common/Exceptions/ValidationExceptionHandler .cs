using Microsoft.AspNetCore.Diagnostics;
using FluentValidation;

namespace ProductManagement.Common.Exceptions;

public class ValidationExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not ValidationException validationException)
        {
            return false;
        }

        var errors = validationException.Errors
            .GroupBy(error => error.PropertyName)
            .ToDictionary(
                group => group.Key,
                group => group.Select(error => error.ErrorMessage).ToArray());

        httpContext.Response.StatusCode =
            StatusCodes.Status400BadRequest;

        await httpContext.Response.WriteAsJsonAsync(
            new
            {
                status = StatusCodes.Status400BadRequest,
                title = "Validation failed",
                errors
            },
            cancellationToken);

        return true;
    }
}
