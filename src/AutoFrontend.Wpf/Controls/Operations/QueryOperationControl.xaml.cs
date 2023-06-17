using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls.Results;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Operations;

public partial class QueryOperationControl : UserControl, IExecutedNotification
{
    private readonly OperationModel operation;

    public QueryOperationControl(ControlFactory controlFactory, OperationModel operation)
    {
        InitializeComponent();

        this.operation = operation;

        expander.Header = operation.Name;

        results.Children.Add(controlFactory.Resolve<Control>(operation.Result));
    }

    private void Expanded(object sender, RoutedEventArgs e)
    {
        Exectue();
    }

    private async void Exectue()
    {
        try
        {
            exception.Visibility = Visibility.Collapsed;
            results.Visibility = Visibility.Collapsed;
            progress.Visibility = Visibility.Visible;

            var result = await ExectueAsync();

            results.Children.OfType<IResultControl>().Single().SetValue(result);
            results.Visibility = Visibility.Visible;
        }
        catch (Exception ex)
        {
            exception.Text = ex.ToString();
            exception.Visibility = Visibility.Visible;
        }
        finally
        {
            progress.Visibility = Visibility.Collapsed;
        }
    }

    private async Task<object?> ExectueAsync()
    {
        if (operation.Result.IsAsync)
        {
            if (operation.Result.Type == typeof(void))
            {
                await (dynamic?)operation.MethodInfo.Invoke(operation.Target, null);
                return null;
            }
            else
            {
                return await (dynamic?)operation.MethodInfo.Invoke(operation.Target, null);
            }
        }
        else
        {
            return await Task.Factory.StartNew(() => operation.MethodInfo.Invoke(operation.Target, null));
        }
    }

    public void OnExecuted()
    {
        if (expander.IsExpanded && autoRefresh.IsChecked == true)
        {
            Exectue();
        }
    }
}
