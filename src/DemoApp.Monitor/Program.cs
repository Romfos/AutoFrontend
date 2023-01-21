using AutoFrontend;
using AutoFrontend.Themes.Monitor;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DemoApp.Monitor;

internal static class Program
{
    [STAThread]
    public static void Main()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.UseMonitorTheme();
        var services = serviceCollection.BuildServiceProvider();
        var frontendApplication = services.GetRequiredService<IFrontendApplication>();
        frontendApplication.Run();

        //ApplicationConfiguration.Initialize();
        //Application.Run(new Form1());
    }
}