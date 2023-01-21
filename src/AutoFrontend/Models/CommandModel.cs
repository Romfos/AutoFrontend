using System;

namespace AutoFrontend.Models;

public sealed class Command
{
    public string Name { get; }
    public Delegate Delegate { get; }

    public Command(string name, Delegate @delegate)
    {
        Name = name;
        Delegate = @delegate;
    }
}
