using AutoFrontend.Models;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class DefaultStringControl : UserControl, IArgumentControl
{
    public DefaultStringControl()
    {
        InitializeComponent();
    }

    public void Setup(Argument argument)
    {
        label.Content = argument.Name;
    }
}
