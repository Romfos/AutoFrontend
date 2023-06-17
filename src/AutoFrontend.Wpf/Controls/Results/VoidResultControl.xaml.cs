using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Results;

public partial class VoidResultControl : UserControl, IResultControl
{
    public VoidResultControl()
    {
        InitializeComponent();
    }

    public void SetValue(object? value)
    {
    }
}
