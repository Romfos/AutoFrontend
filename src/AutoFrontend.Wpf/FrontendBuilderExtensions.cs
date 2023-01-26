using AutoFrontend.Builders;
using AutoFrontend.Wpf.Windows;

namespace AutoFrontend.Wpf;

public static class FrontendBuilderExtensions
{
    public static void RunWpfApplication(this FrontendBuilder autoFrontendBuilder)
    {
        var frontend = autoFrontendBuilder.ToFrontend();
        var mainWindow = new MainWindow();
        mainWindow.Setup(frontend);
        mainWindow.ShowDialog();
    }
}
