using AutoFrontend.Builders;
using System.Windows.Forms;

namespace AutoFrontend.WindowsForms;

public static class AutoFrontendBuilderExtensions
{
    public static void RunWindowsFormsApplication(this AutoFrontendBuilder autoFrontendBuilder)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
#if NET6_0_OR_GREATER
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
#endif

        var autoFrontendFrom = new AutoFrontendFrom();
        var autoFrontendModel = autoFrontendBuilder.ToAutoFrontendModel();
        autoFrontendFrom.SetAutoFrontendModel(autoFrontendModel);
        Application.Run(autoFrontendFrom);
    }
}
