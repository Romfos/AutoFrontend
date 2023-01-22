using System;

namespace AutoFrontend.Models;

public sealed class FieldModel
{
    public Type Type { get; }
    public string Name { get; }

    public FieldModel(Type type, string name)
    {
        Type = type;
        Name = name;
    }
}
