using AutoFrontend.Models;
using AutoFrontend.Wpf.Services;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class DefaultStringControl : UserControl, IArgumentControl
{
    public DefaultStringControl()
    {
        InitializeComponent();
    }

    public void Setup(Argument argument, ServiceLocator servcieLocator)
    {
        label.Content = argument.Name;
    }
}
