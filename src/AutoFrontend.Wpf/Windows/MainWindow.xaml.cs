using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls;
using AutoFrontend.Wpf.Services;
using System.Windows;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Windows;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void Setup(Frontend frontend)
    {
        var servcieLocator = new ServiceLocator(frontend);

        foreach (var service in frontend.Services)
        {
            var serviceControl = new ServiceControl();
            serviceControl.Setup(service, servcieLocator);

            tabs.Items.Add(new TabItem
            {
                Header = service.Name,
                Content = serviceControl
            });
        }
    }
}
