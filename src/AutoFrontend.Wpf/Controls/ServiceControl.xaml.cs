using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls.Functions;
using AutoFrontend.Wpf.Services;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls;

public partial class ServiceControl : UserControl
{
    public ServiceControl()
    {
        InitializeComponent();
    }

    public void Configure(ServiceLocator servcieLocator, Service service)
    {
        foreach (var function in service.Functions)
        {
            var functionControl = new DefaultFunctionControl();
            functionControl.Configure(servcieLocator, function);
            wrapPanel.Children.Add(functionControl);
        }
    }
}
