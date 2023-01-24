using AutoFrontend.Models;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls;

public partial class Int32Control : UserControl, IArgumentControl
{
    public Int32Control()
    {
        InitializeComponent();
    }

    public void Setup(Argument argument)
    {
        groupBox.Header = argument.Name;
    }
}
