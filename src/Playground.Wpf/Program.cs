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

        var applicationFrontendBuilder = new ApplicationFrontendBuilder();
        applicationFrontendBuilder.Service(demoStateService);
        applicationFrontendBuilder.Service(calculatorService);

        var wpfFrontendBuilder = applicationFrontendBuilder
            .BuildWpfFrontend()
            .Title($"Playground wpf application. Runtime version: {Environment.Version}");
        wpfFrontendBuilder.RunWpfApplication();
    }
}