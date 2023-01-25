using AutoFrontend.Models;
using AutoFrontend.Wpf.Services;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class DefaultInt32Control : UserControl, IArgumentControl
{
    public DefaultInt32Control()
    {
        InitializeComponent();
    }

    public void Setup(Argument argument, ServiceLocator servcieLocator)
    {
        label.Content = argument.Name;
    }
}
