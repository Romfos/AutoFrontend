using AutoFrontend.Models;
using AutoFrontend.WindowsForms.Services;
using System.Windows.Forms;

namespace AutoFrontend.WindowsForms.Controls;

public partial class FunctionControl : UserControl
{
    public FunctionControl()
    {
        InitializeComponent();
    }

    public void SetFunction(Function function, ComponentFactroy componentFactroy)
    {
        button.Text = function.Name;

        foreach (var argument in function.Arguments)
        {
            var control = CreateArgumentControl(argument, componentFactroy);
            argumentPanel.Controls.Add(control);
        }

        if (function.Result is not null)
        {
            var control = CreateArgumentControl(function.Result, componentFactroy);
            resultPanel.Controls.Add(control);
        }
    }

    private Control CreateArgumentControl(Argument argument, ComponentFactroy componentFactroy)
    {
        var control = componentFactroy.Create(argument.ValueType);
        if (control is IArgumentControl argumentControl)
        {
            argumentControl.Setup(argument);
        }
        control.Dock = DockStyle.Top;
        return control;
    }
}
