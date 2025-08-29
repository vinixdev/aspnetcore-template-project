using Bookmarks.Domain.Service;
using Bookmarks.Infrastructure;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Shared.Bookmarks.Domain.Service;

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

    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IBookmarkService, BookmarkService>();
    }

    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBookmarkRepository, BookmarkRepository>();
    }
}