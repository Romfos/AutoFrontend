using AutoFrontend.Models;
using System.Windows.Forms;

namespace AutoFrontend.WindowsForms.Controls;

public partial class StringDefaultControl : UserControl, IArgumentControl
{
    public StringDefaultControl()
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
