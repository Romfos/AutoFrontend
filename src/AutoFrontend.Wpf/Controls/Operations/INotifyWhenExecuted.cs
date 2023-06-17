using System;

namespace AutoFrontend.Wpf.Controls.Operations;

public interface INotifyWhenExecuted
{
    event Action? Executed;
}
