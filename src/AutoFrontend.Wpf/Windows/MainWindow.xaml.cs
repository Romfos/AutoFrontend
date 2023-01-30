using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls;
using AutoFrontend.Wpf.Services;
using System.Windows;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Windows;

public partial class MainWindow : Window
{
    public MainWindow(Frontend frontend, GlobalFunctionService globalFunctionService, ControlFactory controlFactory)
    {
        InitializeComponent();

        foreach (var service in frontend.Services)
        {
            var serviceControl = new ServiceControl(service, globalFunctionService, controlFactory);

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
