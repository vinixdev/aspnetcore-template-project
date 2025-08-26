using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

namespace BookmarkManager;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = 500;
        var contextFeature = httpContext.Features.Get<IExceptionHandlerFeature>();

        if (contextFeature != null)
        {
            var globalError = new
            {
                httpContext.Response.StatusCode, exception.Message,
            };

            var serializedGlobalError = JsonSerializer.Serialize(globalError);

            await httpContext.Response.WriteAsync(serializedGlobalError, cancellationToken);
        }

        return true;
    }
}