using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls.Arguments;
using AutoFrontend.Wpf.Services;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Functions;

public partial class DefaultFunctionControl : UserControl
{
    private Function? function;
    private ServiceLocator? serviceLocator;

    public DefaultFunctionControl()
    {
        InitializeComponent();
    }

    public void Configure(ServiceLocator serviceLocator, Function function)
    {
        this.serviceLocator = serviceLocator;
        this.function = function;

        executeButton.Content = function.Name;

        foreach (var argument in function.Arguments)
        {
            var argumentControl = CreateArgumentControl(argument, serviceLocator, false);
            argumentStack.Children.Add(argumentControl);
        }

        var resultControl = CreateArgumentControl(function.Result, serviceLocator, true);
        if (resultControl != null)
        {
            resultStack.Children.Add(resultControl);
        }
    }

    private Control? CreateArgumentControl(Argument argument, ServiceLocator servcieLocator, bool IsReadOnly)
    {
        if (argument.AwaitResultType == typeof(void))
        {
            return null;
        }
        var control = servcieLocator.ControlFactory.Create(argument.AwaitResultType);
        if (control is IArgumentControl argumentControl)
        {
            argumentControl.Configure(servcieLocator, argument, IsReadOnly);
        }
        return control;
    }

    private async void Execute(object sender, RoutedEventArgs e)
    {
        if (function == null)
        {
            throw new Exception($"Field {nameof(function)} is requried");
        }
        if (serviceLocator == null)
        {
            throw new Exception($"Field {nameof(serviceLocator)} is requried");
        }

        resultStack.Visibility = Visibility.Collapsed;
        exceptionTextBox.Visibility = Visibility.Collapsed;
        progressBar.Visibility = Visibility.Visible;

        var parameters = argumentStack.Children
            .Cast<IArgumentControl>()
            .Select(x => x.GetArgumentValue())
            .ToArray();

        try
        {
            var result = await serviceLocator.FunctionExecutor.ExecuteFunctionAsync(function, parameters);
            if (function.Result.AwaitResultType != typeof(void))
            {
                var resultArgumentControl = resultStack.Children.Cast<IArgumentControl>().Single();
                resultArgumentControl.SetArgumentValue(result);
                resultStack.Visibility = Visibility.Visible;
            }
        }
        catch (Exception exception)
        {
            exceptionTextBox.Text = exception.ToString();
            exceptionTextBox.Visibility = Visibility.Visible;
        }

        progressBar.Visibility = Visibility.Collapsed;
    }
}
