using AutoFrontend.Builders;

namespace AutoFrontend.Wpf;

public static class FrontendBuilderExtensions
{
    public static void RunWpfpplication(this FrontendBuilder autoFrontendBuilder)
    {
        var mainWindow = new MainWindow();
        mainWindow.ShowDialog();
    }
}
