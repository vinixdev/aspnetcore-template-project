using BookmarkManager;
using BookmarkManager.Extensions;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.ConfigureCors();
builder.Services.ConfigureRepositories();
builder.Services.ConfigureServices();

//Configure database
// ....

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Bookmarks.AssemblyReference).Assembly));

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;   
})
.AddApplicationPart(typeof(Bookmarks.AssemblyReference).Assembly);

var app = builder.Build();

app.UseExceptionHandler(opt => { });

if (app.Environment.IsProduction())
    app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();