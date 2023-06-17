using AutoFrontend.Builders;
using AutoFrontend.Wpf;
using Playground.Services;
using System;

internal class Program
{
    [STAThread]
    public static void Main()
    {
        var demoStateService = new UserService();
        var calculatorService = new CalculatorService();

        var frontendBuilder = new FrontendBuilder();
        frontendBuilder.Service(demoStateService);
        frontendBuilder.Service(calculatorService);

        var wpfFrontendBuilder = frontendBuilder
            .BuildWpfApplication()
            .Title($"Playground wpf application. Runtime: {Environment.Version}");
        wpfFrontendBuilder.Run();
    }
}