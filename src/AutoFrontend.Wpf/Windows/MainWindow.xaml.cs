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
            serviceControl.Configure(servcieLocator, service);

            tabs.Items.Add(new TabItem
            {
                Header = new TextBlock
                {
                    TextWrapping = TextWrapping.WrapWithOverflow,
                    TextAlignment = TextAlignment.Center,
                    MinWidth = 150,
                    Text = service.Name,
                    TextTrimming = TextTrimming.WordEllipsis,
                },
                Content = serviceControl,
                Padding = new Thickness(5, 10, 5, 10),
            });
        }
    }
}
