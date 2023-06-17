using System;

namespace AutoFrontend.Wpf.Controls.Operations;

public interface IOperationControl
{
    event Action? OnExectued;

    void Refresh();
}
