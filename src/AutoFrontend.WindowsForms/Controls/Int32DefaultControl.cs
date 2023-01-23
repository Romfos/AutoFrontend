using AutoFrontend.Models;
using System.Windows.Forms;

namespace AutoFrontend.WindowsForms.Controls;

public partial class Int32DefaultControl : UserControl, IArgumentControl
{
    public Int32DefaultControl()
    {
        InitializeComponent();
    }

    public Argument? Argument { get; private set; }

    public void Setup(Argument argument)
    {
        Argument = argument;
        groupBox.Text = argument.Name;
    }
}
