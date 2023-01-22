using AutoFrontend.Builders;
using System.Windows.Forms;

namespace AutoFrontend.WindowsForms;

public static class AutoFrontendBuilderExtensions
{
    public static void RunWindowsFormsApplication(this FrontendBuilder autoFrontendBuilder)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
#if NET6_0_OR_GREATER
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
#endif

        var autoFrontendFrom = new AutoFrontendFrom();
        var frontend = autoFrontendBuilder.ToFrontend();
        autoFrontendFrom.SetFrontend(frontend);
        Application.Run(autoFrontendFrom);
    }
}
