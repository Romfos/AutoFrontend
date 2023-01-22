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
        groupBox.Text = function.Name;

        var button = new Button
        {
            Text = function.Name,
            Dock = DockStyle.Top
        };
        groupBox.Controls.Add(button);

        foreach (var parameterInfo in function.MethodInfo.GetParameters())
        {
            var control = componentFactroy.Create(parameterInfo.ParameterType);
            control.Dock = DockStyle.Top;
            groupBox.Controls.Add(control);
        }
    }
}
