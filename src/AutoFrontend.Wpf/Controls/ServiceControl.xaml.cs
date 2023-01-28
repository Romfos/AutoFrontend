using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls.Functions;
using AutoFrontend.Wpf.Services;
using System.Linq;
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
        var actionFunctions = service.Functions
            .Where(function => function.Arguments.Count == 0 && function.Result.AwaitResultType == typeof(void))
            .ToList();

        var queryFunctions = service.Functions.Where(function =>
            function.Arguments.Count == 0
                && function.Result.AwaitResultType != typeof(void));

        var defaultFunctions = service.Functions.Where(function => function.Arguments.Count > 0);

        if (actionFunctions.Any())
        {
            actions.Configure(servcieLocator, actionFunctions);
        }

        foreach (var function in queryFunctions)
        {
            var functionControl = new QueryFunctionControl();
            functionControl.Configure(servcieLocator, function);
            stackPanel.Children.Add(functionControl);
        }

        foreach (var function in defaultFunctions)
        {
            var functionControl = new DefaultFunctionControl();
            functionControl.Configure(servcieLocator, function);
            stackPanel.Children.Add(functionControl);
        }
    }
}
