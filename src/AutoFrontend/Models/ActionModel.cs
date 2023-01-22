using System;

namespace AutoFrontend.Models;

public sealed class ActionModel
{
    public Delegate Delegate { get; }
    public string Name { get; set; }

    public ActionModel(Delegate @delegate)
    {
        Name = @delegate.Method.Name;
        Delegate = @delegate;
    }
}
