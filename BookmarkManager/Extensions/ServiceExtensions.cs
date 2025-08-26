using Microsoft.AspNetCore.Cors.Infrastructure;

namespace BookmarkManager.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.Configure<CorsOptions>(opt =>
        {
            opt.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }
}