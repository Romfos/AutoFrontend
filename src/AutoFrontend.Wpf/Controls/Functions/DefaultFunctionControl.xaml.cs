using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls.Arguments;
using AutoFrontend.Wpf.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Functions;

public partial class DefaultFunctionControl : UserControl
{
    public DefaultFunctionControl()
    {
        InitializeComponent();
    }

    public void Configure(ServiceLocator serviceLocator, Function function)
    {
        executeButton.Content = function.Name;
        executeButton.Click += (_, _) => Execute(serviceLocator, function);

        foreach (var argument in function.Arguments)
        {
            var argumentControl = CreateArgumentControl(argument, serviceLocator);
            argumentStack.Children.Add(argumentControl);
        }

        var resultControl = CreateArgumentControl(function.Result, serviceLocator);
        if (resultControl != null)
        {
            resultStack.Children.Add(resultControl);
        }
    }

    private Control? CreateArgumentControl(Argument argument, ServiceLocator servcieLocator)
    {
        if (argument.ArgumentType == typeof(void))
        {
            return null;
        }
        var control = servcieLocator.ControlFactory.Create(argument.ArgumentType);
        if (control is IArgumentControl argumentControl)
        {
            argumentControl.Configure(servcieLocator, argument);
        }
        return control;
    }

    private async void Execute(ServiceLocator serviceLocator, Function function)
    {
        resultStack.Visibility = Visibility.Collapsed;

        if (argumentStack.Children.Cast<IArgumentControl>().Any(x => !x.IsValid))
        {
            validationControl.Validation(function.Name, "Some arguments are not valid");
            return;
        }

        executeButton.IsEnabled = false;
        progressBar.Visibility = Visibility.Visible;
        validationControl.Reset();

        var parameters = argumentStack.Children
            .Cast<IArgumentControl>()
            .Select(x => x.ArgumentValue)
            .ToArray();

        try
        {
            var result = await serviceLocator.GlobalFunctionService.ExecuteWithNotificationAsync(function, parameters);

            if (function.Result.ArgumentType != typeof(void))
            {
                var resultArgumentControl = resultStack.Children
                    .Cast<IArgumentControl>()
                    .Single();

                resultArgumentControl.ArgumentValue = result;
                resultStack.Visibility = Visibility.Visible;
            }
        }
        catch (Exception exception)
        {
            validationControl.Validation(function.Name, exception);
        }

        executeButton.IsEnabled = true;

        await Task.Delay(300);
        progressBar.Visibility = Visibility.Collapsed;
    }
}
