namespace AutoFrontend.Wpf.Controls.Arguments;

public interface IArgumentControl
{
    object? ArgumentValue { get; set; }

    bool IsValid { get; }
}
