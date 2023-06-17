using AutoFrontend.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls;

public partial class WpfFrontendWindow : Window
{
    private readonly ControlFactory controlFactory;

    public WpfFrontendWindow(ControlFactory controlFactory, FrontendModel frontendModel)
    {
        InitializeComponent();

        foreach (var service in frontendModel.Services)
        {
            var button = new Button
            {
                Content = service.Name,
                Height = 50,
                Margin = new Thickness(1, 1, 1, 1),
            };
            button.Click += (_, _) => SelectService(service);
            services.Children.Add(button);
        }

        this.controlFactory = controlFactory;


        if (frontendModel.Services.Any())
        {
            SelectService(frontendModel.Services.First());
        }
    }

    private void SelectService(ServiceModel service)
    {
        content.Children.Clear();
        var serviceControl = controlFactory.Resolve<Control>(service);
        content.Children.Add(serviceControl);
    }
}
