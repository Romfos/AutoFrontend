using AutoFrontend.Models;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class DefaultInt32Control : UserControl, IArgumentControl
{
    public DefaultInt32Control()
    {
        InitializeComponent();
    }

    public void Setup(Argument argument)
    {
        label.Content = argument.Name;
    }
}
