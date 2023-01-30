using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls.Arguments;
using AutoFrontend.Wpf.Services;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Functions;

public partial class QueryFunctionControl : UserControl
{
    public QueryFunctionControl()
    {
        InitializeComponent();
    }

    public void Configure(ServiceLocator serviceLocator, Function function)
    {
        expander.Header = function.Name;

        expander.Expanded += (_, _) => Execute(serviceLocator, function);
        executeButton.Click += (_, _) => Execute(serviceLocator, function);

        var resultControl = CreateArgumentControl(function.Result, serviceLocator);
        resultStack.Children.Add(resultControl);

        serviceLocator.GlobalFunctionService.OnFunctionExecuted += () =>
        {
            if (autoRefresh.IsChecked == true && expander.IsExpanded)
            {
                Execute(serviceLocator, function);
            }
        };
    }

    private Control CreateArgumentControl(Argument argument, ServiceLocator servcieLocator)
    {
        var control = servcieLocator.ControlFactory.Create(argument.ArgumentType);
        if (control is not IArgumentControl argumentControl)
        {
            throw new Exception("Unable to resolve control");
        }
        argumentControl.Configure(servcieLocator, argument);
        return control;
    }

    private async void Execute(ServiceLocator serviceLocator, Function function)
    {
        executeButton.IsEnabled = false;
        progressBar.Visibility = Visibility.Visible;
        resultStack.Visibility = Visibility.Visible;
        validationControl.Reset();

        try
        {
            var result = await serviceLocator.GlobalFunctionService.ExecuteAsync(function, null);

            if (function.Result.ArgumentType != typeof(void))
            {
                var resultArgumentControl = resultStack.Children
                    .Cast<IArgumentControl>()
                    .Single();

                resultArgumentControl.ArgumentValue = result;
            }
        }
        catch (Exception exception)
        {
            validationControl.Validation(function.Name, exception);
            resultStack.Visibility = Visibility.Collapsed;
        }

        progressBar.Visibility = Visibility.Collapsed;
        executeButton.IsEnabled = true;
    }
}
