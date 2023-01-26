using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls.Arguments;
using AutoFrontend.Wpf.Services;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Functions;

public partial class DefaultFunctionControl : UserControl
{
    public DefaultFunctionControl()
    {
        InitializeComponent();
    }

    public void Configure(ServiceLocator servcieLocator, Function function)
    {
        groupBox.Header = function.Name;
        executeButton.Content = function.Name;

        foreach (var argument in function.Arguments)
        {
            var control = CreateArgumentControl(argument, servcieLocator, false);
            argumentStack.Children.Add(control);
        }

        if (function.Result != null)
        {
            var control = CreateArgumentControl(function.Result, servcieLocator, true);
            resultStack.Children.Add(control);
        }
    }

    private Control? CreateArgumentControl(Argument argument, ServiceLocator servcieLocator, bool IsReadOnly)
    {
        if (argument.ValueType == typeof(void))
        {
            return null;
        }
        var control = servcieLocator.ControlFactory.Create(argument.ValueType);
        if (control is IArgumentControl argumentControl)
        {
            argumentControl.Configure(servcieLocator, argument, IsReadOnly);
        }
        return control;
    }
}
