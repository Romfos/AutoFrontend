using AutoFrontend.Builders;
using AutoFrontend.Wpf.Windows;

namespace AutoFrontend.Wpf;

public static class FrontendBuilderExtensions
{
    public static void RunWpfpplication(this FrontendBuilder autoFrontendBuilder)
    {
        var frontend = autoFrontendBuilder.ToFrontend();
        var mainWindow = new MainWindow();
        mainWindow.Setup(frontend);
        mainWindow.ShowDialog();
    }
}
