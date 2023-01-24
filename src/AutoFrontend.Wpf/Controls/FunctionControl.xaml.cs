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
        executeButton.Content = function.Name;

        foreach (var argument in function.Arguments)
        {
            argumentStack.Children.Add(CreateArgumentControl(argument, controlFactory));
        }

        if (function.Result != null)
        {
            resultStack.Children.Add(CreateArgumentControl(function.Result, controlFactory));
        }
    }

    private Control? CreateArgumentControl(Argument argument, ControlFactory controlFactory)
    {
        if (argument.ValueType == typeof(void))
        {
            return null;
        }
        return controlFactory.Create(argument.ValueType);
    }
}
