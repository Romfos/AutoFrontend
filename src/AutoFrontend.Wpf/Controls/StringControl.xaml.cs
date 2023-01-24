using AutoFrontend.Models;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls;

public partial class StringControl : UserControl, IArgumentControl
{
    public StringControl()
    {
        InitializeComponent();
    }

    public void Setup(Argument argument)
    {
        label.Content = argument.Name;
    }
}
