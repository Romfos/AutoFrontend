using AutoFrontend.Builders;
using AutoFrontend.Wpf;
using Playground.Services;
using System;

internal sealed class Program
{
    [STAThread]
    public static void Main()
    {
        var demoStateService = new UserService();
        var calculatorService = new CalculatorService();

        var frontendBuilder = new FrontendBuilder();
        frontendBuilder.Service(demoStateService);
        frontendBuilder.Service(calculatorService);

        var wpfApplicationBuilder = frontendBuilder
            .BuildWpfApplication()
            .Title($"Playground wpf application. Runtime: {Environment.Version}");
        wpfApplicationBuilder.Run();
    }
}