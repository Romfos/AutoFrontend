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

        actions.Configure(servcieLocator, actionFunctions);

        var functions = service.Functions.Where(function => function.Arguments.Count > 0);

        foreach (var function in functions.Concat(queryFunctions))
        {
            var functionControl = new DefaultFunctionControl();
            functionControl.Configure(servcieLocator, function);
            stackPanel.Children.Add(functionControl);
        }
    }
}
