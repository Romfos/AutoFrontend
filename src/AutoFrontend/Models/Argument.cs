using System;

namespace AutoFrontend.Models;

public sealed class Argument
{
    public string? Name { get; }
    public Type ValueType { get; }

    public Argument(string? name, Type valueType)
    {
        Name = name;
        ValueType = valueType;
    }
}
