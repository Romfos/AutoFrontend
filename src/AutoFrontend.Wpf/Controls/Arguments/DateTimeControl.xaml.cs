using AutoFrontend.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class DateTimeControl : UserControl, IArgumentControl
{
    private readonly Argument argument;

    public DateTimeControl(Argument argument)
    {
        InitializeComponent();
        this.argument = argument;

        datePicker.SelectedDate = DateTime.Now;
        timeTextBox.Text = TimeSpan.Zero.ToString();
        errorLabel.Content = $"Relevant {argument.ArgumentType.FullName} is expected";

        if (argument.ArgumentType == typeof(TimeSpan))
        {
            datePicker.Visibility = Visibility.Collapsed;
        }

#if NET6_0_OR_GREATER
        if (argument.ArgumentType == typeof(TimeOnly))
        {
            datePicker.Visibility = Visibility.Collapsed;
        }
        if (argument.ArgumentType == typeof(DateOnly))
        {
            timeTextBox.Visibility = Visibility.Collapsed;
        }
#endif
        datePicker.SelectedDateChanged += (_, _) => Validate();
        timeTextBox.TextChanged += (_, _) => Validate();
    }

    private void Validate()
    {
        if (IsValid)
        {
            errorLabel.Visibility = Visibility.Collapsed;
        }
        else
        {
            errorLabel.Visibility = Visibility.Visible;
        }
    }

    public object? ArgumentValue
    {
        get
        {
            if (datePicker.SelectedDate is not DateTime dateTime
                || !TimeSpan.TryParse(timeTextBox.Text, out var timeSpan))
            {
                return null;
            }

            if (argument.ArgumentType == typeof(DateTime))
            {
                return dateTime + timeSpan;
            }
            if (argument.ArgumentType == typeof(DateTimeOffset))
            {
                return new DateTimeOffset(dateTime, timeSpan);
            }
            if (argument.ArgumentType == typeof(TimeSpan))
            {
                return timeSpan;
            }

#if NET6_0_OR_GREATER
            if (argument.ArgumentType == typeof(TimeOnly))
            {
                return TimeOnly.FromTimeSpan(timeSpan);
            }
            if (argument.ArgumentType == typeof(DateOnly))
            {
                return DateOnly.FromDateTime(dateTime);
            }
#endif
            throw new NotImplementedException();
        }
        set
        {
            if (argument.ArgumentType == typeof(DateTime) && value is DateTime dateTime)
            {
                datePicker.SelectedDate = dateTime;
                return;
            }
            if (argument.ArgumentType == typeof(DateTimeOffset) && value is DateTimeOffset dateTimeOffset)
            {
                datePicker.SelectedDate = dateTimeOffset.DateTime;
                return;
            }
            if (argument.ArgumentType == typeof(TimeSpan) && value is TimeSpan timeSpan)
            {
                timeTextBox.Text = timeSpan.ToString();
                return;
            }
#if NET6_0_OR_GREATER
            if (argument.ArgumentType == typeof(TimeOnly) && value is TimeOnly timeOnly)
            {
                timeTextBox.Text = timeOnly.ToTimeSpan().ToString();
                return;
            }
            if (argument.ArgumentType == typeof(DateOnly) && value is DateOnly dateOnly)
            {
                datePicker.SelectedDate = dateOnly.ToDateTime(TimeOnly.MinValue);
                return;
            }
#endif

            throw new NotImplementedException();
        }
    }

    public bool IsValid => datePicker.SelectedDate != null
        && TimeSpan.TryParse(timeTextBox.Text, out var timeSpan)
        && timeSpan.TotalDays < 1;
}
