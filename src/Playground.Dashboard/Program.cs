using AutoFrontend;
using AutoFrontend.Applications.Dashboard;
using Playground.Services;
using System;

namespace Playground.Dashboard;

internal static class Program
{
    [STAThread]
    public static void Main()
    {
        var demoStateService = new UserService();

        new AutoFrontendBuilder()
            .Query(demoStateService.GetUsers)
            .Command(demoStateService.AddUser)
            .Command(demoStateService.DeleteUser)
            .Run(new DashboardApplication($"Playground.Dashboard CLR: {Environment.Version}"));
    }
}