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

    public void Setup(Function function, ComponentFactroy componentFactroy)
    {
        executeButton.Content = function.Name;

        foreach (var argument in function.Arguments)
        {
            argumentStack.Children.Add(CreateArgumentControl(argument, componentFactroy));
        }

        if (function.Result != null)
        {
            resultStack.Children.Add(CreateArgumentControl(function.Result, componentFactroy));
        }
    }

    private Control? CreateArgumentControl(Argument argument, ComponentFactroy componentFactroy)
    {
        if (argument.ValueType == typeof(void))
        {
            return null;
        }
        return componentFactroy.Create(argument.ValueType);
    }
}
