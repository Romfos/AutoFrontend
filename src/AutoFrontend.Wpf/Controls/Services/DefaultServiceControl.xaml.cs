using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls.Operations;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace AutoFrontend.Wpf.Controls.Services;

public partial class DefaultServiceControl : UserControl
{
    public DefaultServiceControl(ControlFactory controlFactory, ServiceModel service)
    {
        InitializeComponent();

        AddOperationControls(controlFactory, service.Operations.Where(x => x.Arguments.Count == 0 && x.Result.Type != typeof(void)));
        AddOperationControls(controlFactory, service.Operations.Where(x => x.Arguments.Count == 0 && x.Result.Type == typeof(void)));
        AddOperationControls(controlFactory, service.Operations.Where(x => x.Arguments.Count > 0));
    }

    private void AddOperationControls(ControlFactory controlFactory, IEnumerable<OperationModel> serviceOperations)
    {
        foreach (var operation in serviceOperations)
        {
            var control = controlFactory.Resolve<Control>(operation);

            control.Background = operations.Children.Count % 2 == 0 ? Brushes.WhiteSmoke : Brushes.White;
            if (control is IOperationControl operationControl)
            {
                operationControl.OnExectued += () => Refresh(operationControl);
            }

            operations.Children.Add(control);
        }
    }

    private void Refresh(IOperationControl sender)
    {
        foreach (var controls in operations.Children.OfType<IOperationControl>().Where(x => x != sender))
        {
            controls.Refresh();
        }
    }
}
