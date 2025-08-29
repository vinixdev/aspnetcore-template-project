using BookmarkManager.Context;
using BookmarkManager.Repository;
using Bookmarks.Domain.Service;
using Bookmarks.Infrastructure.Repository;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Bookmarks.Domain.Service;
using Microsoft.EntityFrameworkCore;
using Shared.Repository;

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
        services.AddScoped(typeof(IRepositoryManager<>), typeof(EfRepositoryManager<>));
        services.AddScoped<IBookmarkRepository, BookmarkRepository>();
    }

    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<Context.RepositoryContext>(opts =>
        {
            opts.UseNpgsql(configuration.GetConnectionString("sqlConnection"));
        });
    }
}