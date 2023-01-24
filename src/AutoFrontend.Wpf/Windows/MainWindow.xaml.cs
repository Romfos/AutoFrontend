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
        var componentFactroy = new ControlFactory(frontend.Components);

        foreach (var service in frontend.Services)
        {
            var stackPanel = new StackPanel
            {
                VerticalAlignment = VerticalAlignment.Top,
            };

            foreach (var function in service.Functions)
            {
                var functionControl = new FunctionControl();
                functionControl.Setup(function, componentFactroy);
                stackPanel.Children.Add(functionControl);
            }

            tabs.Items.Add(new TabItem
            {
                Header = service.Name,
                Content = new ScrollViewer
                {
                    VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                    CanContentScroll = true,
                    Content = stackPanel
                }
            });
        }
    }
}
