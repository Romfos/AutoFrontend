using AutoFrontend.Models;
using System.Windows.Controls;
using System.Windows.Media;

namespace AutoFrontend.Wpf.Controls.Services;

public partial class DefaultServiceControl : UserControl
{
    public DefaultServiceControl(ControlFactory controlFactory, ServiceModel service)
    {
        InitializeComponent();

        for (var i = 0; i < service.Operations.Count; i++)
        {
            var operationControl = controlFactory.Resolve<Control>(service.Operations[i]);

            operationControl.Background = i % 2 == 0 ? Brushes.WhiteSmoke : Brushes.White;

            operations.Children.Add(operationControl);
        }
    }
}
