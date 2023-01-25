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

    public void Setup(Service service, ServiceLocator servcieLocator)
    {
        foreach (var function in service.Functions)
        {
            var functionControl = new DefaultFunctionControl();
            functionControl.Setup(function, servcieLocator);
            grid.Children.Add(functionControl);
        }
    }
}
