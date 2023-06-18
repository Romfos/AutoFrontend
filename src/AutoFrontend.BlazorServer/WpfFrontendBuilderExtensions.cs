using AutoFrontend.Builders;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AutoFrontend.BlazorServer;

public static class BlazorServerFrontendBuilderExtensions
{
    public static WebApplication BuildBlazorServerApplication(this FrontendBuilder frontendBuilder)
    {
        var builder = WebApplication.CreateBuilder();

        builder.Services.AddSingleton(frontendBuilder.ToFrontendModel());
        builder.Services.AddRazorPages().AddApplicationPart(Assembly.GetExecutingAssembly());
        builder.Services.AddServerSideBlazor();

        var app = builder.Build();

        app.UseStaticFiles();
        app.UseRouting();
        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        return app;
    }
}
