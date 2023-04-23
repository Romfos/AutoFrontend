using AutoFrontend.Models;
using AutoFrontend.Wpf.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AutoFrontend.Wpf.Controls;

public partial class AutoFrontendWindow : Window
{
    public AutoFrontendWindow(ApplicationFrontend applicationFrontend, EditorControlFactory editorControlFactory)
    {
        InitializeComponent();

        var servicesBorder = new Border
        {
            Background = Brushes.Black,
            Height = 2,
            Margin = new Thickness(0, 5, 0, 5),
        };

        servicesStackPanel.Children.Add(servicesBorder);

        foreach (var service in applicationFrontend.Services)
        {
            var serviceButton = new Button
            {
                Content = service.Name,
                Height = 40,
            };

            serviceButton.Click += (_, _) => contentViewer.Content = new ServiceControl(service, editorControlFactory);

            servicesStackPanel.Children.Add(serviceButton);
        }
    }
}
