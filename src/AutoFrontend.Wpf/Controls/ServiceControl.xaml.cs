using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls.Functions;
using AutoFrontend.Wpf.Services;
using System.Linq;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls;

public partial class ServiceControl : UserControl
{
    public ServiceControl(Service service, GlobalFunctionService globalFunctionService, ControlFactory controlFactory)
    {
        InitializeComponent();

        ConfigureSimpleFunctions(service, globalFunctionService);
        ConfigureQueryFunctions(service, globalFunctionService, controlFactory);
        ConfigureDefaultFunctions(service, globalFunctionService, controlFactory);
    }

    private void ConfigureSimpleFunctions(Service service, GlobalFunctionService globalFunctionService)
    {
        var functions = service.Functions
            .Where(function => function.Arguments.Count == 0 && function.Result.ArgumentType == typeof(void))
            .ToList();

        if (functions.Any())
        {
            var simpleFunctionsControl = new SimpleFunctionsControl(globalFunctionService, functions);
            stackPanel.Children.Add(simpleFunctionsControl);
        }
    }

    private void ConfigureQueryFunctions(Service service, GlobalFunctionService globalFunctionService, ControlFactory controlFactory)
    {
        var functionControls = service.Functions
            .Where(function => function.Arguments.Count == 0 && function.Result.ArgumentType != typeof(void))
            .Select(function => new QueryFunctionControl(function, globalFunctionService, controlFactory));

        foreach (var functionControl in functionControls)
        {
            stackPanel.Children.Add(functionControl);
        }
    }

    private void ConfigureDefaultFunctions(Service service, GlobalFunctionService globalFunctionService, ControlFactory controlFactory)
    {
        var functionControls = service.Functions
            .Where(function => function.Arguments.Count > 0)
            .Select(function => new DefaultFunctionControl(function, globalFunctionService, controlFactory));

        foreach (var functionControl in functionControls)
        {
            stackPanel.Children.Add(functionControl);
        }
    }
}
