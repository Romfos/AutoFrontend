using AutoFrontend.Models;
using AutoFrontend.Wpf.Services;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls;

public partial class FunctionControl : UserControl
{
    public FunctionControl()
    {
        InitializeComponent();
    }

    public void Setup(Function function, ControlFactory controlFactory)
    {
        groupBox.Header = function.Name;
        executeButton.Content = function.Name;

        foreach (var argument in function.Arguments)
        {
            var control = CreateArgumentControl(argument, controlFactory);
            argumentStack.Children.Add(control);
        }

        if (function.Result != null)
        {
            var control = CreateArgumentControl(function.Result, controlFactory);
            resultStack.Children.Add(control);
        }
    }

    private Control? CreateArgumentControl(Argument argument, ControlFactory controlFactory)
    {
        if (argument.ValueType == typeof(void))
        {
            return null;
        }
        var control = controlFactory.Create(argument.ValueType);
        if (control is IArgumentControl argumentControl)
        {
            argumentControl.Setup(argument);
        }
        return control;
    }
}
