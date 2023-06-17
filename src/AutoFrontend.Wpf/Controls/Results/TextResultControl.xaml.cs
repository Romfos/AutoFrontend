using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Results;

public partial class TextResultControl : UserControl, IResultControl
{
    public TextResultControl()
    {
        InitializeComponent();
    }

    public void SetValue(object? value)
    {
        textBox.Text = value?.ToString() ?? "null";
    }
}
