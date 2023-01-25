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

    public void Setup(Service service, ControlFactory controlFactory)
    {
        foreach (var function in service.Functions)
        {
            var functionControl = new DefaultFunctionControl();
            functionControl.Setup(function, controlFactory);
            wrapPanel.Children.Add(functionControl);
        }
    }
}
