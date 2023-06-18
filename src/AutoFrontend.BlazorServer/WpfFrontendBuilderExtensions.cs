using AutoFrontend.BlazorServer.Data;
using AutoFrontend.Builders;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace AutoFrontend.BlazorServer;

public static class BlazorServerFrontendBuilderExtensions
{
    public static WebApplication BuildBlazorServerApplication(this FrontendBuilder frontendBuilder)
    {
        var builder = WebApplication.CreateBuilder();

        // Add services to the container.
        builder.Services.AddRazorPages().AddApplicationPart(Assembly.GetExecutingAssembly());
        builder.Services.AddServerSideBlazor();
        builder.Services.AddSingleton<WeatherForecastService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }

        app.UseStaticFiles();
        app.UseRouting();
        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        return app;
    }
}
