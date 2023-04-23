using System;

namespace AutoFrontend.Models;

public sealed class Argument
{
    public string Name { get; }
    public Type Type { get; }

    public Argument(string name, Type type)
    {
        Name = name;
        Type = type;
    }
}
