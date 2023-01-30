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
    private readonly Function function;
    private readonly GlobalFunctionService globalFunctionService;

    public DefaultFunctionControl(
        Function function,
        GlobalFunctionService globalFunctionService,
        ControlFactory controlFactory)
    {
        InitializeComponent();

        this.function = function;
        this.globalFunctionService = globalFunctionService;

        executeButton.Content = function.Name;
        executeButton.Click += (_, _) => Execute();

        foreach (var argument in function.Arguments)
        {
            var argumentControl = controlFactory.Create(argument);
            argumentStack.Children.Add(argumentControl);
        }

        if (function.Result.ArgumentType != typeof(void))
        {
            var argumentControl = controlFactory.Create(function.Result);
            resultStack.Children.Add(argumentControl);
        }
    }

    private async void Execute()
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
            var result = await globalFunctionService.ExecuteWithNotificationAsync(function, parameters);

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
