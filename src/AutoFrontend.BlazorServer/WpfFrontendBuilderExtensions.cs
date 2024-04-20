using AutoFrontend.Builders;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AutoFrontend.BlazorServer;

public static class BlazorServerFrontendBuilderExtensions
{
    public static WebApplication BuildBlazorServerApplication(this FrontendBuilder frontendBuilder)
    {
        var builder = WebApplication.CreateBuilder();

        builder.Services.AddSingleton(frontendBuilder.ToFrontendModel());
        builder.Services.AddRazorComponents().AddInteractiveServerComponents();

        var app = builder.Build();

        app.UseStaticFiles();
        app.UseAntiforgery();
        app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

        return app;
    }
}
