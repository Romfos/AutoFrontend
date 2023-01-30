using AutoFrontend.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using TestFixture;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class CustomStringControl : UserControl, IArgumentControl
{
    private readonly Argument argument;
    private readonly Fixture fixture;

    public Func<string, object?>? TryParseDelegate { get; set; }

    public CustomStringControl(Argument argument, Fixture fixture)
    {
        InitializeComponent();

        this.argument = argument;
        this.fixture = fixture;

        label.Content = argument.Name;
        errorLabel.Content = $"Relevant {argument.ArgumentType.FullName} is expected";

        textBox.IsReadOnly = argument.IsResult;
        textBox.TextChanged += TextBox_TextChanged;

        GenerateRandomValue();
    }

    public object? ArgumentValue
    {
        get => TryParseDelegate?.Invoke(textBox.Text);
        set => textBox.Text = value?.ToString();
    }

    public bool IsValid => TryParseDelegate?.Invoke(textBox.Text) != null;

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (TryParseDelegate != null && TryParseDelegate.Invoke(textBox.Text) == null)
        {
            errorLabel.Visibility = Visibility.Visible;
        }
        else
        {
            errorLabel.Visibility = Visibility.Collapsed;
        }
    }

    private void GenerateRandomValue()
    {
        try
        {
            var value = fixture.Create(argument.ArgumentType);
            textBox.Text = value.ToString();
        }
        catch (Exception)
        {
            textBox.Text = "Unable to generate random value";
        }
    }
}
