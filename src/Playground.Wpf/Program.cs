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

        var applicationBuilder = new FrontendBuilder();
        applicationBuilder.Service(demoStateService);
        applicationBuilder.RunWpfApplication();
    }
}