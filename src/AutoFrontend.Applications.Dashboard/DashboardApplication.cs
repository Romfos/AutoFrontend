using System.Collections.Generic;
using System.Windows.Forms;
using AutoFrontend.Models;

namespace AutoFrontend.Applications.Dashboard;

public sealed class DashboardApplication : IApplicationRuntime
{
    private readonly string title;

    public DashboardApplication(string title)
    {
        this.title = title;
    }

    public void Run(ApplicationModel applicationModel)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
#if NET6_0_OR_GREATER
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
#endif
        var dashboardForm = new DashboardForm();
        dashboardForm.Text = title;
        Application.Run(dashboardForm);
    }
}
