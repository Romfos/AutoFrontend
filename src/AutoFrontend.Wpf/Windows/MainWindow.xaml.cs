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
        var controlFactory = new ControlFactory(frontend.Components);

        foreach (var service in frontend.Services)
        {
            var serviceControl = new ServiceControl();
            serviceControl.Setup(service, controlFactory);

            tabs.Items.Add(new TabItem
            {
                Header = service.Name,
                Content = serviceControl
            });
        }
    }
}
